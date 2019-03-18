using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            //context.Database.CreateIfNotExists();
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant()
                {
                    Name = "Sabatino's",
                    City = "Balitimore",
                    Country = "USA",
                    Reviews = new List<RestaurantReview>()
                    {
                        new RestaurantReview()
                        {
                            Rating = 5,
                            Body = "please work",
                            ReviewerName = "Frank"
                        }
                    }
                },
                new Restaurant() { Name = "Great Lake", City = "Chicago", Country = "USA" },
                new Restaurant()
                {
                    Name = "Smaka",
                    City = "Gothenburg",
                    Country = "Sweden",
                    Reviews =
                        new List<RestaurantReview>()
                        {
                            new RestaurantReview(){ Rating = 9, Body = "Great Food!", ReviewerName = "Fred"}
                        }

                });
        }
    }
}
