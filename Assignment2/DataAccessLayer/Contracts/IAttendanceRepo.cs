using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IAttendanceRepo
    {
        void Add(Attendance attendance);
        void Delete(Attendance attendance);
        List<Attendance> GetAll();
        Attendance GetByID(int ID);
        void Update(Attendance attendance);
    }
}
