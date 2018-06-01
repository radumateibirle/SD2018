using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickAndPickup.Models
{
    public class MealListModel
    {
        public List<MealModel> mm { get; set; }
        public MealListModel()
        {
            mm = new List<MealModel>();
        }
    }
}