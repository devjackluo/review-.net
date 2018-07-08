using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{

    [Authorize]
    public class HomeController: Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter) {

            _restaurantData = restaurantData;
            _greeter = greeter;

        }

        [AllowAnonymous]
        public IActionResult Index() {

            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            //returning json
            //return new ObjectResult(model);



            return View(model);

        }

        //does whatever it can to get id
        //looks in routing data before query string
        public IActionResult Details(int id) {

            var model = _restaurantData.Get(id);

            if (model == null) {
                //for api
                //return NotFound();

                //return NotFound.cshtml
                //return View("NotFound");

                return RedirectToAction("Index");
                //or
                //return RedirectToAction(nameof(Index));

            }

            return View(model);

        }

        [AllowAnonymous]
        [HttpGet]
        //[Authorize]
        public IActionResult Create() {

            //if(User.Identity.IsAuthenticated)
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        //any post has a token and putting this checks that token
        [ValidateAntiForgeryToken]
        //asp takes the posted data and tries to create this parameter model
        public IActionResult Create(RestaurantEditModel model) {

            if (ModelState.IsValid) {

                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;

                newRestaurant = _restaurantData.Add(newRestaurant);

                //return View("Details", newRestaurant);
                //redirect so they can't keep posting if they refresh.
                //extra anonomous variable not part of routing will become url get params.
                //return RedirectToAction(nameof(Details), new { id = newRestaurant.Id, foo="bar"});
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });

            } else {

                //return RedirectToAction(nameof(Create));
                return View();

            }

        }

    }
}
