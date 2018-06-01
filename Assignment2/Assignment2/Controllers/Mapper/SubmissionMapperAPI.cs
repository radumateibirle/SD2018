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
    public class SubmissionMapperAPI : ISubmissionMapperAPI
    {
        public SubmissionModelAPI Map(SubmissionModel sub)
        {
            return new SubmissionModelAPI()
            {
                AssignmentID = sub.AssignmentID,
                StudentID = sub.StudentID,
                GitLink = sub.GitLink,
                Grade = sub.Grade,
                Notes = sub.Notes
            };
        }

        public SubmissionModel Map(SubmissionModelAPI sub)
        {
            return new SubmissionModel()
            {
                AssignmentID = sub.AssignmentID,
                StudentID = sub.StudentID,
                GitLink = sub.GitLink,
                Grade = sub.Grade,
                Notes = sub.Notes
            }; ;
        }
    }
}