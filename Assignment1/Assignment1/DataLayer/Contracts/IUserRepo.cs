using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment1.DataLayer.Models;

namespace Assignment1.DataLayer.Contracts
{
    interface IUserRepo
    {
        List<UserDTO> getUsers();
        bool createUser(UserDTO user);
        bool updateUser(UserDTO user);
        bool deleteUserByID(int ID);
    }
}
