using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Mapper;
using Assignment2.BussinessLogicLayer.Models;
using BussinessLogicLayer.Contracts;
using DataAccessLayer;
using DataAccessLayer.Contracts;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Services
{
    public class AttendanceServices : IAttendanceServices
    {
        IAttendanceRepo aRepo;
        IAttendanceMapper aMapper = new AttendanceMapper();

        public AttendanceServices(IAttendanceRepo aR)
        {
            aRepo = aR;
        }

        public void Add(AttendanceModel attendanceModel)
        {
            aRepo.Add(aMapper.Map(attendanceModel));
        }

        public void Delete(AttendanceModel attendanceModel)
        {
            aRepo.Delete(aMapper.Map(attendanceModel));
        }

        public List<AttendanceModel> GetAll()
        {
            List<Attendance> attendances = aRepo.GetAll();
            List<AttendanceModel> attendanceModel = new List<AttendanceModel>();

            attendances.ForEach(a => attendanceModel.Add(aMapper.Map(a)));
            return attendanceModel;
        }

        public AttendanceModel GetByID(int ID)
        {
            return aMapper.Map(aRepo.GetByID(ID));
        }

        public void Update(AttendanceModel attendanceModel)
        {
            aRepo.Update(aMapper.Map(attendanceModel));
        }
    }
}
