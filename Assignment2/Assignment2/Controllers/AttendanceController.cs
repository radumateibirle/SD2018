using Assignment2.BussinessLogicLayer.Models;
using Assignment2.Controllers.Contracts;
using Assignment2.Controllers.Mapper;
using Assignment2.Models;
using BussinessLogicLayer.Contracts;
using BussinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class AttendanceController : ApiController
    {
        IAttendanceServices aServices;
        IAttendanceMapperAPI aMapper = new AttendanceMapperAPI();

        public AttendanceController(IAttendanceServices aS)
        {
            aServices = aS;
        }

        // GET: api/Attendance
        public IEnumerable<AttendanceModel> Get()
        {
            return aServices.GetAll();
        }

        // GET: api/Attendance/5
        public AttendanceModel Get(int id)
        {
            return aServices.GetByID(id);
        }

        // POST: api/Attendance
        public void Post([FromBody]AttendanceModelAPI value)
        {
            aServices.Add(aMapper.Map(value));
        }

        [Route("api/Attendance/Edit")]
        // PUT: api/Attendance/5
        public void Put([FromBody]AttendanceModel value)
        {
            aServices.Update(value);
        }

        [Route("api/Attendance/{id}")]
        // DELETE: api/Attendance/5
        public void Delete(int id)
        {
            aServices.Delete(aServices.GetByID(id));
        }
    }
}
