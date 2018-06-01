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
    public class LaboratoryController : ApiController
    {
        ILaboratoryServices lServices;
        ILaboratoryMapperAPI lMapper = new LaboratoryMapperAPI();

        public LaboratoryController(ILaboratoryServices lS)
        {
            lServices = lS;
        }

        // GET: api/Laboratory
        public IEnumerable<LaboratoryModel> Get()
        {
            return lServices.GetAll();
        }

        // GET: api/Laboratory/5
        public LaboratoryModel Get(int id)
        {
            if (id == 0) return null;
            return lServices.GetByID(id);
        }

        [Route("api/Laboratory/{keyword}")]
        // GET: api/Laboratory/keyword
        public IEnumerable<LaboratoryModel> Get(string keyword)
        {
            return lServices.GetFilteredList(keyword);
        }

        // POST: api/Laboratory
        public void Post([FromBody]LaboratoryModelAPI value)
        {
            lServices.Add(lMapper.Map(value));
        }

        // PUT: api/Laboratory/5
        public void Put([FromBody]LaboratoryModel value)
        {
            lServices.Update(value);
        }

        [Route("api/Laboratory/{id}")]
        // DELETE: api/Laboratory/5
        public void Delete(int id)
        {
            if (id == 0) return;
            lServices.Delete(lServices.GetByID(id));
        }
    }
}
