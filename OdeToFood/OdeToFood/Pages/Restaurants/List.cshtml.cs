using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
	    private readonly IConfiguration _configuration;
	    private readonly IRestaurantData _restaurantData;

	    public string Message { get; set; }

		[BindProperty(SupportsGet = true)]
	    public string SearchTerm { get; set; }
	    
	    public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
	        _configuration = configuration;
	        _restaurantData = restaurantData;
        }

        public void OnGet()
        {
	        Message = _configuration["Message"];
	        Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}