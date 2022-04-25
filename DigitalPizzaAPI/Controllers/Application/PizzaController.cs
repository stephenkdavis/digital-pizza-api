using DigitalPizzaAPI.Models;
using DigitalPizzaAPI.Models.DbModels;
using DigitalPizzaAPI.Models.DtoModels;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalPizzaAPI.Controllers.Application
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : BaseController
    {
        public PizzaController(DataContext context) : base(context) { }

        [HttpGet]
        [Route("Preset")]
        public async Task<ActionResult<PresetPizzaDto>> GetPresetPizza(int id)
        {
            var predicate = PredicateBuilder.New<PresetPizza>(true);
            predicate = (id > 0) ? predicate.And(p => p.PresetId.Equals(id)) : predicate.And(p => p.PresetId > 0);

            var list = await data.PresetPizzas
                .Where(predicate)
                .Select(p => new PresetPizzaDto
                {
                    PizzaId = p.PresetId,
                    PizzaName = p.Name,
                    SmallPrice = p.BasePrice,
                    MediumPrice = p.BasePrice + 3,
                    LargePrice = p.BasePrice + 6,
                    PartyPrice = p.BasePrice + 12
                })
                .ToArrayAsync();

            if (list == null)
                return NoContent();

            foreach (var item in list)
            {
                var toppings = await data.PresetToppings
                    .Join(data.ToppingList, t => t.ToppingId, tl => tl.ToppingId, (t, tl) => new { t, tl })
                    .Where(ttl => ttl.t.PresetId.Equals(item.PizzaId))
                    .Select(ttl => new ToppingDto
                    {
                        ToppingId = ttl.t.ToppingId,
                        CategoryId = ttl.tl.CategoryId,
                        ToppingName = ttl.tl.Name,
                        IsPremium = ttl.tl.IsPremium
                    })
                    .ToArrayAsync();
                item.Toppings = toppings;
            }

            return Ok(list);
        }
    }
}
