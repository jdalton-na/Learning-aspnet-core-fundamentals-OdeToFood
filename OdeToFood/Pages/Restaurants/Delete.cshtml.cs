using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public DeleteModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData ?? throw new ArgumentNullException(nameof(restaurantData));
        }

        public Restaurant Restaurant { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }


        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = _restaurantData.Delete(restaurantId);
            _restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} was deleted";
            return RedirectToPage("./List");
        }
    }
}
