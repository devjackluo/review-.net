using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        //inheriting the DbContext and doing : base(options)
        //does all the magic of connecting to the database
        public OdeToFoodDbContext(DbContextOptions options) : base(options) {
            
        }

    }
}
