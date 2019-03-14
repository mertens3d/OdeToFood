using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class RestaurantReview
    {

        public int Id { get; set; }
        public ICollection<RestaurantReview> Reviews { get; set; }
        public string Body { get; set; }
        public int RestaurantId { get; set; }

    }
}