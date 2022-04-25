using DigitalPizzaAPI.Models;
using DigitalPizzaAPI.Models.DbModels;
using DigitalPizzaAPI.Models.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DigitalPizzaAPI.Controllers.Application
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : BaseController
    {
        public OrderController(DataContext context) : base(context) { }

        [HttpGet]
        [Route("Retrieve")]
        public async Task<IActionResult> GetOrder(int id)
        {
            if (id <= 0)
                return BadRequest(NewReturnMessage("The order id must be greater than zero."));

            int userClaim = GetClaimAccountId();
            string roleClaim = GetClaimRole();

            Order dbOrder = new();
            if (roleClaim.Equals("Employee"))
                dbOrder = await data.Orders.Where(o => o.OrderId.Equals(id)).FirstOrDefaultAsync();
            else
                dbOrder = await data.Orders.Where(o => o.OrderId.Equals(id) && o.CustomerId.Equals(userClaim)).FirstOrDefaultAsync();

            if (dbOrder == null)
                return BadRequest(NewReturnMessage("No order found for the order id #" + id));

            var dbItems = await data.OrderItems.Where(i => i.OrderId.Equals(id)).ToArrayAsync();
            var dbPizzas = await data.OrderPizzas.Where(p => p.OrderId.Equals(id)).ToArrayAsync();
            var dbAddress = await data.Addresses.FindAsync(dbOrder.AddressId);

            ArrayList list = new();

            AddressDto address = new()
            {
                Label = dbAddress.Label,
                StreetNumber = dbAddress.StreetNumber,
                StreetName = dbAddress.StreetName,
                UnitNumber = dbAddress.UnitNumber,
                City = dbAddress.City,
                Province = dbAddress.Province,
                PostCode = dbAddress.PostCode,
                Notes = dbAddress.Notes
            };

            OrderDto order = new()
            {
                OrderId = id,
                Timestamp = dbOrder.Timestamp,
                Total = dbOrder.Total
            };

            OrderPizzaDto[] pizzas = new OrderPizzaDto[dbPizzas.Length];
            int pizzaIndex = 0;
            foreach (var pizza in dbPizzas)
            {
                var item = dbItems.Where(i => i.PizzaId.Equals(pizza.PizzaId)).First();
                OrderPizzaDto x = new()
                {
                    PizzaSize = pizza.PizzaSize,
                    IsWellDone = pizza.IsWellDone,
                    IsPreset = pizza.IsPreset,
                    PresetId = pizza.PresetId,
                    Quantity = item.Quantity
                };
                x.Toppings = await data.OrderToppings
                    .Join(data.ToppingList, t => t.ToppingId, l => l.ToppingId, (t, l) => new { t, l })
                    .Where(w => w.t.PizzaId.Equals(pizza.PizzaId))
                    .Select(w => new ToppingDto
                    {
                        ToppingName = w.l.Name
                    })
                    .ToArrayAsync();
                pizzas[pizzaIndex] = x;
                pizzaIndex++;
            }
            order.Pizzas = pizzas;

            int drinkIndex = 0;
            int drinkCount = dbItems.Where(i => i.DrinkId > 0).Count();
            MultipleItemDto[] drinks = new MultipleItemDto[drinkCount];
            foreach (var item in dbItems)
            {
                if (item.DrinkId == 0)
                    continue;

                string name = await data.DrinkList.Where(d => d.Id.Equals(item.DrinkId)).Select(d => d.Name).FirstOrDefaultAsync();
                drinks[drinkIndex] = new MultipleItemDto
                {
                    ItemId = item.DrinkId,
                    ItemName = name,
                    Quantity = item.Quantity
                };
                drinkIndex++;
            }
            order.Drinks = drinks;

            list.Add(order);
            list.Add(address);

            return Ok(list);
        }

        [HttpGet]
        [Route("History")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<OrderDto>> GetHistory()
        {
            int userClaim = GetClaimAccountId();

            var list = await data.Orders
                .Where(o => o.CustomerId.Equals(userClaim))
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    Timestamp = o.Timestamp,
                    Total = o.Total
                })
                .ToArrayAsync();

            if (list == null)
                return NoContent();

            return Ok(list);
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> PostOrder(OrderDto order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            const double toppingPrice = 1.5;
            const double baseSmall = 15;
            const double baseMedium = 18;
            const double baseLarge = 21;
            const double baseParty = 27;
            double total = 0;

            int userClaim = GetClaimAccountId();
            DateTime timestamp = DateTime.Now;

            Order newOrder = new()
            {
                CustomerId = userClaim,
                AddressId = order.AddressId,
                Timestamp = timestamp,
                InOven = false,
                IsOnRoute = false
            };

            data.Orders.Add(newOrder);
            await data.SaveChangesAsync();
            int orderId = newOrder.OrderId;

            foreach (var pizza in order.Pizzas)
            {
                OrderPizza op = new()
                {
                    PizzaSize = pizza.PizzaSize,
                    IsWellDone = pizza.IsWellDone
                };

                if (pizza.IsPreset)
                {
                    op.IsPreset = true;
                    op.PresetId = pizza.PizzaId;

                    total += await data.PresetPizzas.Where(p => p.PresetId.Equals(pizza.PizzaId)).Select(p => p.BasePrice).FirstOrDefaultAsync();
                }

                data.OrderPizzas.Add(op);
                await data.SaveChangesAsync();

                if (!pizza.IsPreset)
                {
                    switch (pizza.PizzaSize)
                    {
                        default:
                        case 1:
                            total += baseSmall;
                            break;
                        case 2:
                            total += baseMedium;
                            break;
                        case 3:
                            total += baseLarge;
                            break;
                        case 4:
                            total += baseParty;
                            break;
                    }

                    int pizzaId = op.PizzaId;
                    foreach (var topping in pizza.Toppings)
                    {
                        total += topping.IsPremium ? (toppingPrice * 2) : toppingPrice;
                        OrderToppings ot = new()
                        {
                            PizzaId = pizzaId,
                            ToppingId = topping.ToppingId
                        };
                        data.OrderToppings.Add(ot);
                    }
                    await data.SaveChangesAsync();
                }
            }

            foreach (var drink in order.Drinks)
            {
                var temp = await data.DrinkList.FindAsync(drink.ItemId);
                if (temp != null)
                    total += temp.IsPremium ? (2.5 * drink.Quantity) : (1.5 * drink.Quantity);
                else
                    total += 2.5 * drink.Quantity;
                OrderItem item = new()
                {
                    OrderId = orderId,
                    Quantity = drink.Quantity,
                    DrinkId = drink.ItemId
                };
                data.OrderItems.Add(item);
            }

            // delivery charge
            total += 3;

            // add taxes of 13%
            total *= 1.13;

            newOrder.Total = total;

            var customer = await data.Customers.FindAsync(userClaim);
            customer.RewardsCount++;
            data.Customers.Update(customer);

            data.Orders.Update(newOrder);
            await data.SaveChangesAsync();

            return Ok(NewReturnMessage("Order Created."));
        }

        [HttpPut]
        [Route("Update")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> PutUpdate(OrderUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int employeeClaim = GetClaimAccountId();

            var order = await data.Orders.FindAsync(dto.OrderId);
            var employee = await data.People.FindAsync(employeeClaim);
            var role = await data.Employees.FindAsync(employeeClaim);

            if (order == null)
                return NoContent();

            if (employee == null || role == null)
                return BadRequest(NewReturnMessage("Please sign in again. An error occured getting the employee profile."));

            bool isManager = role.RoleId.Equals(1);
            bool isCook = role.RoleId.Equals(2);
            bool isDriver = role.RoleId.Equals(3);
            bool ovenChange = !order.InOven.Equals(dto.InOven);
            bool routeChange = !order.IsOnRoute.Equals(dto.IsOnRoute);
            bool deliverChange = !order.IsDelivered.Equals(dto.IsDelivered);

            DateTime timestamp = DateTime.Now;
            string status = "";

            if (ovenChange && (isManager || isCook))
            {
                status = "Pizza In Oven";
                order.InOven = true;
                order.IsOnRoute = false;
                order.IsDelivered = false;
            }

            if (ovenChange && isDriver)
                return Unauthorized(NewReturnMessage("You do not have the permissions to make this change."));

            if (routeChange && (isManager || isCook || isDriver))
            {
                status = "Out For Delivery";
                order.InOven = false;
                order.IsOnRoute = true;
                order.IsDelivered = false;
            }

            if (deliverChange && (isManager || isDriver))
            {
                status = "Order Delivered";
                order.InOven = false;
                order.IsOnRoute = false;
                order.IsDelivered = true;
            }

            if (deliverChange && isCook)
                return Unauthorized(NewReturnMessage("You do not have the permissions to make this change."));

            string msg = $"Order #{dto.OrderId} - {status} - Last updated on {timestamp.ToShortDateString} at {timestamp.ToShortTimeString} by {employee.FirstName} {employee.LastName}";

            order.StatusMessage = msg;

            data.Orders.Update(order);
            await data.SaveChangesAsync();

            return Ok(NewReturnMessage("Order Updated."));
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id <= 0)
                return BadRequest(NewReturnMessage("Please enter a valid order number."));

            int employeeClaim = GetClaimAccountId();
            var employee = await data.Employees.FindAsync(employeeClaim);

            if (employee == null)
                return BadRequest(NewReturnMessage("An error occurred when trying to get employee profile. Please try again."));

            if (!employee.RoleId.Equals(1))
                return Unauthorized(NewReturnMessage("You do not have the necessary permissions to delete an order. Please contact your manager."));

            Order order = await data.Orders.FindAsync(id);
            OrderItem[] items = await data.OrderItems.Where(i => i.OrderId.Equals(id)).ToArrayAsync();
            OrderPizza[] pizzas = await data.OrderPizzas.Where(p => p.OrderId.Equals(id)).ToArrayAsync();

            foreach (var pizza in pizzas)
            {
                OrderToppings[] toppings = await data.OrderToppings.Where(t => t.PizzaId.Equals(pizza.PizzaId)).ToArrayAsync();
                foreach (var topping in toppings)
                    if (topping != null)
                        data.OrderToppings.Remove(topping);
                data.OrderPizzas.Remove(pizza);
            }

            foreach (var item in items)
                data.OrderItems.Remove(item);

            data.Orders.Remove(order);
            int result = await data.SaveChangesAsync();

            if (result == 0)
                return Ok(NewReturnMessage("No orders deleted."));

            return Ok(NewReturnMessage($"Order #{id} has been deleted."));
        }
    }
}
