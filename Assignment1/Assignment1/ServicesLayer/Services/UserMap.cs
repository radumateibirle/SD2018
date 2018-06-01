using Assignment1.DataLayer.Models;
using Assignment1.ServicesLayer.Contracts;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Services
{
    class UserMap : IUserMap
    {
        public UserModel map(UserDTO userdto)
        {
            UserModel user = new UserModel();

            user.setFunction(userdto.getFunction());
            user.setID(userdto.getID());
            user.setHashedPassword(userdto.getPassword());
            user.setUsername(userdto.getUsername());

            return user;
        }

        public UserDTO map(UserModel usermodel)
        {
            UserDTO user = new UserDTO();

            user.setUsername(usermodel.getUsername());
            user.setPassword(usermodel.getPassword());
            user.setID(usermodel.getID());
            user.setFunction(usermodel.getFunction());

            return user;
        }
    }
}
