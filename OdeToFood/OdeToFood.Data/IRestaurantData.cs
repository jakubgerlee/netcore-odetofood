using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Core;

namespace OdeToFood.Data
{
	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetRestaurantByName(string name);
		Restaurant GetRestaurantById(int id);
		Restaurant Update(Restaurant updatedRestaurant);
		int Commit();
	}

	public class InMemoryRestaurantData: IRestaurantData
	{
		private readonly List<Restaurant> _restaurants;
		public InMemoryRestaurantData()
		{
			_restaurants = new List<Restaurant>
			{
				 new Restaurant
				 {
					 Id = 1,
					 Name = "Scott's Pizza",
					 Cuisine = CuisineType.Italian,
					 Location = "MaryLand"
				 },
				 new Restaurant
				 {
					 Id = 2,
					 Name = "Mehikano",
					 Cuisine = CuisineType.Mexican,
					 Location = "Warsaw"
				 },
				 new Restaurant
				 {
					 Id = 3,
					 Name = "Mariano Italiano",
					 Cuisine = CuisineType.Italian,
					 Location = "MaryLand"
				 },
				 new Restaurant
				 {
					 Id = 4,
					 Name = "Hindian",
					 Cuisine = CuisineType.Indian,
					 Location = "MaryLand"
				 }
			};
		}

		public IEnumerable<Restaurant> GetRestaurantByName(string name)
		{
			return from restaurant in _restaurants
				where string.IsNullOrEmpty(name) ||
				      restaurant.Name.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)
				orderby restaurant.Name
				select restaurant;
		}

		public Restaurant GetRestaurantById(int id)
		{
			return _restaurants.SingleOrDefault(x => x.Id == id);
		}

		public Restaurant Update(Restaurant updatedRestaurant)
		{
			var restaurant = _restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
			if (restaurant != null)
			{
				restaurant.Name = updatedRestaurant.Name;
				restaurant.Cuisine = updatedRestaurant.Cuisine;
				restaurant.Location = updatedRestaurant.Location;
			}

			return restaurant;
		}

		public int Commit()
		{
			return 0;
		}
	}
}
