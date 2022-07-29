using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Api
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly  OdeToFoodDbContext _context;

        public RestaurantsController(OdeToFoodDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRetaurantsAsync()
        {
            var restaurants = await _context.Restaurants.OrderBy(c => c.Name).ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var restaurant = await _context.Restaurants.SingleOrDefaultAsync(c => c.Id == Id);

            if (restaurant == null) return NotFound();  

            return Ok(restaurant);

        }
    }
}
