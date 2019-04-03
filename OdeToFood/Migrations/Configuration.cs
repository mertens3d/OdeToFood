using OdeToFood.Models;
using System.Collections.Generic;
using System.Web.Security;
using WebMatrix.WebData;

namespace OdeToFood.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationDataLossAllowed = true;
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

            //for (int i = 0; i < 1000; i++)
            //{
            //    context.Restaurants.AddOrUpdate(r => r.Name, 
            //        new Restaurant(){Name = i.ToString(), City = "Nowhere", Country = "USA"});
            //}

            SeedMembership();
        }

        private void SeedMembership()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "userName", autoCreateTables: true);
            }

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }

            if (membership.GetUser("sallen", false) == null)
            {
                membership.CreateUserAndAccount("sallen", "imalittleteapot");
            }

            if (!roles.GetRolesForUser("sallen").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "sallen" }, new[] { "admin" });
            }
        }
    }
}
