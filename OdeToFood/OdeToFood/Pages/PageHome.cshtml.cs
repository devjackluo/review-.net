using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Pages
{
    public class PageHomeModel : PageModel
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeIndexViewModel hmodel { get; set; }

        public PageHomeModel(IRestaurantData restaurantData, IGreeter greeter) {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public void OnGet()
        {

            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            //returning json
            //return new ObjectResult(model);
            hmodel = model;


        }
    }
}