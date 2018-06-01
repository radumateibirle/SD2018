using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;
using BussinessLogicLayer.Services;
using Assignment2.BussinessLogicLayer.Models;
using Assignment2.Controllers.Contracts;
using Assignment2.Models;
using Assignment2.Controllers.Mapper;
using BussinessLogicLayer.Contracts;

namespace Assignment2.Controllers
{
    public class UsersController : ApiController
    {
        IUserServices uServices;
        IUserMapperAPI uMapper = new UserMapperAPI();

        public UsersController(IUserServices uS)
        {
            uServices = uS;
        }

        // GET: api/Users
        public IEnumerable<UserModel> Get()
        {
            return uServices.GetAll();
        }

        // GET: api/Users/5
        public UserModel Get(int id)
        {
            return uServices.GetByID(id);
        }

        // POST: api/Users
        public string Post([FromBody]UserModel user)
        {
            var u = new UserModel() {  Type = user.Type, Email = user.Email};
            return uServices.Add(u);
        }


        [Route("api/Users/Update")]
        // PUT: api/Users/Update
        public void Put([FromBody]UserModel value)
        {
            uServices.Update(value);
        }

        [Route("api/Users/{id}")]
        // DELETE: api/Users/5
        public void Delete(int id)
        {
            uServices.Delete(uServices.GetByID(id));
        }
    }
}
