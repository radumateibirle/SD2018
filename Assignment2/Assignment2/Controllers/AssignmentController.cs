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
    public class AssignmentController : ApiController
    {
        IAssignmentServices aServices;
        ILaboratoryServices lServices;
        IAssignmentMapperAPI aMapper = new AssignmentMapperAPI();

        public AssignmentController(IAssignmentServices aS, ILaboratoryServices lS)
        {
            aServices = aS;
            lServices = lS;
        }

        // GET: api/Assignment
        public IEnumerable<AssignmentModel> Get()
        {
            return aServices.GetAll();
        }

        // GET: api/Assignment/5
        public AssignmentModel Get(int id)
        {
            return aServices.GetByID(id);
        }


        [Route("api/Assignment/ForLab/{labNr}")]
        // GET: api/Assignment/ForLab/{labNr}
        public IEnumerable<AssignmentModel> GetAssignments(int labNr)
        {
            int labID = lServices.GetIdFromNumber(labNr);
            return aServices.GetByLabID(labID);
        }

        // POST: api/Assignment
        public void Post([FromBody]AssignmentModelAPI value)
        {
            aServices.Add(aMapper.Map(value));
        }

        [Route("api/Assignment/Edit")]
        // PUT: api/Assignment/5
        public void Put([FromBody]AssignmentModel value)
        {
            aServices.Update(value);
        }

        [Route("api/Assignment/{id}")]
        // DELETE: api/Assignment/5
        public void Delete(int id)
        {
            aServices.Delete(aServices.GetByID(id));
        }
    }
}
