using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    internal class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }

        public RatingResult ComputeResult(IRatingAlgorithm algorithm, int numberOfReviews)
        {
            var filteredReviews = _restaurant.Reviews.Take(numberOfReviews);
            return algorithm.Compute(filteredReviews.ToList());
            
        }
    }
}