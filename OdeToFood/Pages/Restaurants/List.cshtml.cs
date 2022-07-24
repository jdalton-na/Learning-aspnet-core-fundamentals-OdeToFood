using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OldeToFood.Core;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData _restaurantData;
        public string? Message = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, 
                         IRestaurantData restaurantData)
        {
            this.config = config;
            _restaurantData = restaurantData;
        }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public void OnGet()
        {
            this.Message = $"This is from config {config["Message"]} it is {System.DateTime.Now}";
            Restaurants = _restaurantData.GetRestaurantsByName(this.SearchTerm);
        }
    }
}
