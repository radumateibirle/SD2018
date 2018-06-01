using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickAndPickup.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public UserModel User { get; set; }
        
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date { get; set; }
        public string QRCodePath { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public VoucherModel Voucher { get; set; }
        
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EstimatedTime { get; set; }
        public List<MealModel> Meals { get; set; }
    }
}