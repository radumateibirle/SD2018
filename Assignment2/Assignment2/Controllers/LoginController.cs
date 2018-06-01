using Assignment2.BussinessLogicLayer.Models;
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
    public class LoginController : ApiController
    {
        IUserServices uServices;

        public LoginController(IUserServices uS)
        {
            uServices = uS;
        }
        
        [Route("api/Login/{token}")]
        // POST: api/Login/{token}
        public string Post(string token, [FromBody]UserModelAPI usermodel)
        {
            UserModel attempt = null;
            attempt = uServices.GetByToken(token);

            if(attempt != null)
            {
                return "Token does not exist!";
            }
            if (attempt.Password != null)
            {
                return "User already registered";
            }

            attempt.FullName = usermodel.FullName;
            attempt.GroupName = usermodel.GroupName;
            attempt.Hobby = usermodel.Hobby;
            attempt.Password = usermodel.Password;
            uServices.Update(attempt);
            return "Registered successfully! User is " + attempt.Type;
        }

        [Route("api/Login")]
        // POST: api/Login/{mail}/{password}
        public string Post([FromBody]UserModelAPI objUser)
        {
            UserModel attempt = null;

            attempt = uServices.GetByEmail(objUser.Email);
            if(attempt == null)
            {
                return null;
            }
            else if(attempt.Password == objUser.Password)
            {
                return attempt.Type;
            }
            return null;
        }
    }
}
