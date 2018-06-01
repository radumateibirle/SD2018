using Assignment1.DataLayer.Models;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface IUserService
    {
        List<UserModel> getUsers();
        UserModel getUserByID(int ID);
        int login(UserModel user);
        bool isUsername(string name);
        bool isID(int ID);
        bool add(UserModel user);
        bool update(UserModel user);
        bool delete(int ID);
    }
}
