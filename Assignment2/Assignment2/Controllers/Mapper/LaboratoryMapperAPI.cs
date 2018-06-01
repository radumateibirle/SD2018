using Assignment2.BussinessLogicLayer.Models;
using Assignment2.Controllers.Contracts;
using Assignment2.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Controllers.Mapper
{
    public class LaboratoryMapperAPI : ILaboratoryMapperAPI
    {
        public LaboratoryModelAPI Map(LaboratoryModel lab)
        {
            return new LaboratoryModelAPI()
            {
                Curricula = lab.Curricula,
                Date = lab.Date,
                Description = lab.Description,
                Number = lab.Number,
                Title = lab.Title
            };
        }

        public LaboratoryModel Map(LaboratoryModelAPI lab)
        {
            return new LaboratoryModel()
            {
                Curricula = lab.Curricula,
                Date = lab.Date,
                Description = lab.Description,
                Number = lab.Number,
                Title = lab.Title
            };
        }
    }
}