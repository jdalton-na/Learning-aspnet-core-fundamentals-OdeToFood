using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public EntityState Modified { get; private set; }

        public Restaurant Add(Restaurant newRestaurant)
        {
            this.dbContext.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return this.dbContext.SaveChanges() ;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = this.dbContext.Restaurants.FirstOrDefault(c => c.Id == id);
            if (restaurant != null)
            {
                this.dbContext.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return dbContext.Restaurants.FirstOrDefault(c => c.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return dbContext.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return dbContext.Restaurants
                .Where(c => c.Name.StartsWith(name) || string.IsNullOrWhiteSpace(name))
                .OrderBy(c => c.Name)
                .ToList(); ;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entiy = dbContext.Restaurants.Attach(updateRestaurant);
            entiy.State = Modified;
            return updateRestaurant;
        }
    }
}
