using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {

        private readonly IRestaurantData _restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData ?? throw new ArgumentNullException(nameof(restaurantData));
        }

        public IViewComponentResult Invoke()
        {
            int count = _restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
