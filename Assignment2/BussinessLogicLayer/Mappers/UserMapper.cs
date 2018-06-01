using Assignment2.BussinessLogicLayer.Contracts;
using Assignment2.BussinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.BussinessLogicLayer.Mapper
{
    public class UserMapper : IUserMapper
    {
        public UserModel Map(User user)
        {
            return new UserModel()
            {
                Email = user.Email,
                FullName = user.FullName,
                GroupName = user.GroupName,
                Hobby = user.Hobby,
                ID = user.ID,
                Password = user.Password,
                Token = user.Token,
                Type = user.Type
            };
        }
        public User Map(UserModel user)
        {
            return new User()
            {
                Email = user.Email,
                FullName = user.FullName,
                GroupName = user.GroupName,
                Hobby = user.Hobby,
                ID = user.ID,
                Password = user.Password,
                Token = user.Token,
                Type = user.Type
            };
        }
    }
}