using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class EditModel : PageModel
    {
	    private readonly IRestaurantData _restaurantData;
	    private readonly IHtmlHelper _htmlHelper;
	    public IEnumerable<SelectListItem> Cuisines { get; set; }

		[BindProperty(SupportsGet = true)]
	    public Restaurant Restaurant { get; set; }

	    public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
	    {
		    _restaurantData = restaurantData;
		    _htmlHelper = htmlHelper;
	    }
        public IActionResult OnGet(int restaurantId)
        {
	        Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
	        Restaurant = _restaurantData.GetRestaurantById(restaurantId);
	        if (Restaurant == null)
	        {
		        return RedirectToPage("./NotFound");
	        }
	        return Page();
        }

        public IActionResult OnPost()
        {
	        _restaurantData.Update(Restaurant);
	        _restaurantData.Commit();
	        return Page();
        }
    }
}