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
    public class AttendanceMapperAPI : IAttendanceMapperAPI
    {
        public AttendanceModelAPI Map(AttendanceModel att)
        {
            return new AttendanceModelAPI()
            {
                LaboratoryID = att.LaboratoryID,
                StudentID = att.StudentID
            };
        }

        public AttendanceModel Map(AttendanceModelAPI att)
        {
            return new AttendanceModel()
            {
                LaboratoryID = att.LaboratoryID,
                StudentID = att.StudentID
            };
        }
    }
}