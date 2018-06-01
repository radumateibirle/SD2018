using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class UserModelAPI
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string GroupName { get; set; }
        public string FullName { get; set; }
        public string Hobby { get; set; }
    }
}