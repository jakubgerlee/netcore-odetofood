﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class DetailModel : PageModel
    {
	    private readonly IRestaurantData _restaurantData;
	    public Restaurant Restaurant { get; set; }

	    public DetailModel(IRestaurantData restaurantData)
	    {
		    _restaurantData = restaurantData;
	    }
        public IActionResult OnGet(int restaurantId)
        {
	        Restaurant = _restaurantData.GetRestaurantById(restaurantId);
	        if (Restaurant == null)
	        {
		        return RedirectToPage("./NotFound");
	        }
	        return Page();

        }
    }
}