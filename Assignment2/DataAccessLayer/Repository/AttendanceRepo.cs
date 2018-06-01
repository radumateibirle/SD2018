using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class AttendanceRepo:IAttendanceRepo
    {
        Assignment2Entities DB = new Assignment2Entities();
        public void Add(Attendance attendance)
        {
            if (attendance == null) return;
            DB.Attendances.Add(attendance);
            DB.SaveChanges();
        }

        public void Delete(Attendance attendance)
        {
            if (attendance == null) return;
            var att = DB.Attendances.FirstOrDefault(a => a.ID == attendance.ID);
            if (att == null) return;
            DB.Attendances.Remove(att);
            DB.SaveChanges();
        }

        public List<Attendance> GetAll()
        {
            return DB.Attendances.ToList();
        }

        public Attendance GetByID(int ID)
        {
            return DB.Attendances.FirstOrDefault(l => l.ID == ID);
        }

        public void Update(Attendance attendance)
        {
            if (attendance == null) return;
            var att = DB.Attendances.FirstOrDefault(a => a.ID == attendance.ID);
            if (att == null) return;
            DB.Entry(att).CurrentValues.SetValues(attendance);
            DB.SaveChanges();
        }
    }
}
