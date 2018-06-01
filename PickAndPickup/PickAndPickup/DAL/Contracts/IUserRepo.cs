using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUserRepo
    {
        void Add(User user);
        void Delete(int userID);
        void Update(User user);
        List<User> GetAll();
        List<User> GetCurrent();
        User GetByID(int ID);
        User GetByEmail(string email);
    }
}
