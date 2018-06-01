using Assignment2.BussinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Contracts
{
    public interface IUserServices
    {
        string Add(UserModel userModel);
        void Delete(UserModel userModel);
        List<UserModel> GetAll();
        UserModel GetByID(int ID);
        UserModel GetByToken(string Token);
        UserModel GetByEmail(string Email);
        void Update(UserModel userModel);
    }
}
