﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData {

        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context) {

            _context = context;

        }

        public Restaurant Add(Restaurant restaurant) {

            //put on hold to add
            _context.Restaurants.Add(restaurant);
            //actually add it
            _context.SaveChanges();
            return restaurant;

        }

        public Restaurant Get(int id) {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll() {

            return _context.Restaurants.OrderBy(r => r.Name);

        }

        public Restaurant Update(Restaurant restaurant) {

            //_context.Restaurants.Update(restaurant);
            _context.Attach(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return restaurant;

        }
    }
}