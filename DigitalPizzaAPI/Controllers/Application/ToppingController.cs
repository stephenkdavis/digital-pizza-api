using DigitalPizzaAPI.Models;
using DigitalPizzaAPI.Models.DbModels;
using DigitalPizzaAPI.Models.DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalPizzaAPI.Controllers.Application
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : BaseController
    {
        public ToppingController(DataContext context) : base(context) { }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<ToppingDto>> GetToppingList()
        {
            var list = await data.ToppingList
                .Select(t => new ToppingDto()
                {
                    ToppingId = t.ToppingId,
                    CategoryId = t.CategoryId,
                    ToppingName = t.Name,
                    IsPremium = t.IsPremium
                })
                .ToArrayAsync();

            if (list == null)
                return NoContent();

            return Ok(list);
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<ActionResult<ToppingCategoryDto>> GetToppingCategoryList()
        {
            var list = await data.ToppingCategories
                .Select(c => new ToppingCategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name
                })
                .ToArrayAsync();

            if (list == null)
                return NoContent();

            return Ok(list);
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> NewTopping(ToppingDto topping)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ToppingList newTopping = new()
            {
                CategoryId = topping.CategoryId,
                Name = topping.ToppingName,
                IsPremium = topping.IsPremium
            };

            data.ToppingList.Add(newTopping);
            int result = await data.SaveChangesAsync();

            if (result <= 0)
                return BadRequest(NewReturnMessage("Something went wrong creating the new topping."));

            return Ok(NewReturnMessage("Topping successfully created."));
        }
    }
}
