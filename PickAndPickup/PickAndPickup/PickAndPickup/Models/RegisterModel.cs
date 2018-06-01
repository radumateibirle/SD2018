using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickAndPickup.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Mail { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public string Type;
        public string Password { get; set; }
    }
}