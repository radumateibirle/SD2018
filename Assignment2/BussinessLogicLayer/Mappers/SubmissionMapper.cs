using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Mapper
{
    public class SubmissionMapper : ISubmissionMapper
    {
        public SubmissionModel Map(Submission sub)
        {
            return new SubmissionModel()
            {
                AssignmentID = sub.AssignmentID,
                StudentID = sub.StudentID,
                GitLink = sub.GitLink,
                Grade = sub.Grade,
                ID = sub.ID,
                Notes = sub.Notes
            };
        }

        public Submission Map(SubmissionModel sub)
        {
            return new Submission()
            {
                AssignmentID = sub.AssignmentID,
                StudentID = sub.StudentID,
                GitLink = sub.GitLink,
                Grade = sub.Grade,
                ID = sub.ID,
                Notes = sub.Notes
            }; ;
        }
    }
}