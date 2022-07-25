using OldeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant Add(Restaurant newRestaurant);
        Restaurant Update(Restaurant updateRestaurant);

        Restaurant GetById(int id);

        int Commit();
    }


}
