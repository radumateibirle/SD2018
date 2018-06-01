using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Mapper
{
    public class AssignmentMapper : IAssignmentMapper
    {
        public AssignmentModel Map(Assignment assign)
        {
            return new AssignmentModel()
            {
                Deadline = assign.Deadline,
                Description = assign.Description,
                ID = assign.ID,
                LaboratoryID = assign.LaboratoryID,
                Name = assign.Name
            };
        }

        public Assignment Map(AssignmentModel assign)
        {
            return new Assignment()
            {
                Deadline = assign.Deadline,
                Description = assign.Description,
                ID = assign.ID,
                LaboratoryID = assign.LaboratoryID,
                Name = assign.Name
            };
        }
    }
}