using OldeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants = new List<Restaurant>()
        {
            new Restaurant
            {
                Id = 1,
                Name = "Scott's Pizza",
                Location = "Maryland",
                Cuisine = Restaurant.CuisineType.Fast_Food
            },
            new Restaurant
            {
                Id = 2,
                Name = "Chens Chinese Restaurant",
                Location = "Shelby, North Carolina",
                Cuisine = Restaurant.CuisineType.Chinese
            },
            new Restaurant
            {
                Id = 3,
                Name = "Wildflower Bakery",
                Location = "Saluda, North Carolina",
                Cuisine = Restaurant.CuisineType.American
            }
        };

        public Restaurant GetById(int id)
        {
            // id validation checks - zero trust

            return _restaurants.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            // name validation - zero trust

            if (String.IsNullOrWhiteSpace(name))
            {
                return _restaurants.OrderBy(x => x.Name);
            }
            else
            {
                return _restaurants.FindAll(x => x.Name.StartsWith(name)).OrderBy(x => x.Name);
            }
        }
    }
}