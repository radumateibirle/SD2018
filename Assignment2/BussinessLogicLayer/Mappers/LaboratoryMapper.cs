using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Mapper
{
    public class LaboratoryMapper : ILaboratoryMapper
    {
        public LaboratoryModel Map(Laboratory lab)
        {
            return new LaboratoryModel()
            {
                Curricula = lab.Curricula,
                Date = lab.Date,
                Description = lab.Description,
                ID = lab.ID,
                Number = lab.Number,
                Title = lab.Title
            };
        }

        public Laboratory Map(LaboratoryModel lab)
        {
            return new Laboratory()
            {
                Curricula = lab.Curricula,
                Date = lab.Date,
                Description = lab.Description,
                ID = lab.ID,
                Number = lab.Number,
                Title = lab.Title
            };
        }
    }
}