using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IUserRepo
    {
        void Add(User user);
        void Delete(User user);
        List<User> GetAll();
        User GetByID(int ID);
        User GetByToken(string Token);
        User GetByEmail(string Email);
        void Update(User user);
    }
}
