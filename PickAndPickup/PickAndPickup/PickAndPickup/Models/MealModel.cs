using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickAndPickup.Models
{
    public class MealModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string PhotoPath { get; set; }
    }
}