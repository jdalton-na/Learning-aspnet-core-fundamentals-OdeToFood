using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OldeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; } = new Restaurant();

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            this.Restaurant = _restaurantData.GetById(restaurantId);
            if (this.Restaurant == null)
            {
                return RedirectToPage("./RestaurantNotFound");
            }
            return Page();
        }
    }
}
