using Assignment2.BussinessLogicLayer.Models;
using Assignment2.Controllers.Contracts;
using Assignment2.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Controllers.Mapper
{
    public class UserMapperAPI : IUserMapperAPI
    {
        public UserModelAPI Map(UserModel user)
        {
            return new UserModelAPI()
            {
                Email = user.Email,
                FullName = user.FullName,
                GroupName = user.GroupName,
                Hobby = user.Hobby,
                Password = user.Password
            };
        }
        public UserModel Map(UserModelAPI user)
        {
            return new UserModel()
            {
                Email = user.Email,
                FullName = user.FullName,
                GroupName = user.GroupName,
                Hobby = user.Hobby,
                Password = user.Password
            };
        }
    }
}