using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Models
{
    public class AssignmentModel
    {
        public int ID { get; set; }
        public int LaboratoryID { get; set; }
        public string Name { get; set; }
        public System.DateTime Deadline { get; set; }
        public string Description { get; set; }
    }
}