﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Models
{
    public class LaboratoryModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Curricula { get; set; }
        public System.DateTime Date { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
    }
}