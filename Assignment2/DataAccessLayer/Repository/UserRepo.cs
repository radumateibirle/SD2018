using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepo : IUserRepo
    {
        Assignment2Entities DB = new Assignment2Entities();
        public void Add(User user)
        {
            if (user == null) return;
            DB.Users.Add(user);
            DB.SaveChanges();
        }

        public void Delete(User user)
        {
            if (user == null) return;
            var us = DB.Users.FirstOrDefault(u => u.ID == user.ID);
            var aR = new AttendanceRepo();
            var att = aR.GetAll();
            foreach (var a in att)
            {
                if (a.StudentID == us.ID) aR.Delete(a);
            }

            var sR = new SubmissionRepo();
            var sub = sR.GetAll();
            foreach (var s in sub)
            {
                if (s.StudentID == us.ID) sR.Delete(s);
            }
            if (us == null) return;
            DB.Users.Remove(us);
            DB.SaveChanges();
        }

        public List<User> GetAll()
        {
            return DB.Users.ToList();
        }

        public User GetByEmail(string Email)
        {
            return DB.Users.FirstOrDefault(u => u.Email == Email);
        }

        public User GetByID(int ID)
        {
            return DB.Users.FirstOrDefault(u => u.ID == ID);
        }

        public User GetByToken(string Token)
        {
            return DB.Users.FirstOrDefault(u => u.Token == Token);
        }

        public void Update(User user)
        {
            if (user == null) return;
            var us = DB.Users.FirstOrDefault(u => u.ID == user.ID);
            if (us == null) return;
            DB.Entry(us).CurrentValues.SetValues(user);
            DB.SaveChanges();
        }
    }
}
