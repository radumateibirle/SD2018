using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Models
{
    public class AttendanceModel
    {
        public int ID { get; set; }
        public int LaboratoryID { get; set; }
        public int StudentID { get; set; }
    }
}