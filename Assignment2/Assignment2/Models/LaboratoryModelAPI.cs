using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class LaboratoryModelAPI
    {
        public string Title { get; set; }
        public string Curricula { get; set; }
        public System.DateTime Date { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
    }
}