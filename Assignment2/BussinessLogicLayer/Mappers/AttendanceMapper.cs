using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Mapper
{
    public class AttendanceMapper : IAttendanceMapper
    {
        public AttendanceModel Map(Attendance att)
        {
            return new AttendanceModel()
            {
                ID = att.ID,
                LaboratoryID = att.LaboratoryID,
                StudentID = att.StudentID
            };
        }

        public Attendance Map(AttendanceModel att)
        {
            return new Attendance()
            {
                ID = att.ID,
                LaboratoryID = att.LaboratoryID,
                StudentID = att.StudentID
            };
        }
    }
}