using Assignment1.DataLayer.Models;
using Assignment1.ServicesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1.ServicesLayer.Contracts
{
    interface IUserMap
    {
        UserModel map(UserDTO userdto);
        UserDTO map(UserModel usermodel);
    }
}
