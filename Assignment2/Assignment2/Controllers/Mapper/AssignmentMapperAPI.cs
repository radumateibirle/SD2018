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
    public class AssignmentMapperAPI : IAssignmentMapperAPI
    {
        public AssignmentModelAPI Map(AssignmentModel assign)
        {
            return new AssignmentModelAPI()
            {
                Deadline = assign.Deadline,
                Description = assign.Description,
                LaboratoryID = assign.LaboratoryID,
                Name = assign.Name
            };
        }

        public AssignmentModel Map(AssignmentModelAPI assign)
        {
            return new AssignmentModel()
            {
                Deadline = assign.Deadline,
                Description = assign.Description,
                LaboratoryID = assign.LaboratoryID,
                Name = assign.Name
            };
        }
    }
}