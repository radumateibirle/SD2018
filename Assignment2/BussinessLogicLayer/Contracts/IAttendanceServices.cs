using Assignment2.BussinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Contracts
{
    public interface IAttendanceServices
    {
        void Add(AttendanceModel attendanceModel);
        void Delete(AttendanceModel attendanceModel);
        List<AttendanceModel> GetAll();
        AttendanceModel GetByID(int ID);
        void Update(AttendanceModel attendanceModel);
    }
}
