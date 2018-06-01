using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class UserRepo : IUserRepo
    {

        PickAndPickupEntities DB = new PickAndPickupEntities();
        public void Add(User user)
        {
            if (user == null) return;
            DB.Users.Add(user);
            DB.SaveChanges();
        }

        public void Delete(int userID)
        {
            if (userID < 1) return;
            var usr = DB.Users.FirstOrDefault(u => u.ID == userID);
            if (usr == null) return;
            usr.IsDeleted = true;
            DB.Entry(usr).CurrentValues.SetValues(usr);

            var UserVouchers = DB.UserVouchers.ToList();
            var Vouchers = DB.Vouchers.ToList();
            foreach (UserVoucher uv in UserVouchers)
            {
                if (uv.UserID == userID)
                {
                    uv.IsDeleted = true;
                    DB.Entry(uv).CurrentValues.SetValues(uv);
                    foreach (Voucher v in Vouchers)
                    {
                        if (v.ID == uv.VoucherID)
                        {
                            v.IsDeleted = true;
                            DB.Entry(v).CurrentValues.SetValues(v);
                        }
                    }
                }
            }
            DB.SaveChanges();
        }

        public List<User> GetAll()
        {
            return DB.Users.ToList();
        }

        public User GetByEmail(string email)
        {
            return this.GetCurrent().FirstOrDefault(u => u.Mail == email);
        }

        public User GetByID(int ID)
        {
            return this.GetCurrent().FirstOrDefault(u => u.ID == ID);
        }

        public List<User> GetCurrent()
        {
            var Users = DB.Users.ToList();
            List<User> cusr = new List<User>();
            foreach (User u in Users)
            {
                if (u.IsDeleted != true)
                {
                    cusr.Add(u);
                }
            }
            return cusr;
        }

        public void Update(User user)
        {
            if (user == null) return;
            var usr = DB.Users.FirstOrDefault(u => u.ID == user.ID);
            if (usr == null) return;
            DB.Entry(usr).CurrentValues.SetValues(user);
            DB.SaveChanges();
        }
    }
}