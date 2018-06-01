using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class UserVoucherRepo : IUserVoucherRepo
    {
        PickAndPickupEntities DB = new PickAndPickupEntities();
        public void Add(UserVoucher uservoucher)
        {
            if (uservoucher == null) return;
            DB.UserVouchers.Add(uservoucher);
            DB.SaveChanges();
        }

        public void Delete(int uservoucherID)
        {
            if (uservoucherID < 1) return;
            var usrvcr = DB.UserVouchers.FirstOrDefault(u => u.ID == uservoucherID);
            if (usrvcr == null) return;
            usrvcr.IsDeleted = true;
            DB.Entry(usrvcr).CurrentValues.SetValues(usrvcr);
            DB.SaveChanges();
        }

        public List<UserVoucher> GetAll()
        {
            return DB.UserVouchers.ToList();
        }

        public UserVoucher GetByID(int ID)
        {
            return this.GetCurrent().FirstOrDefault(u => u.ID == ID);
        }

        public List<UserVoucher> GetCurrent()
        {
            var UserVouchers = DB.UserVouchers.ToList();
            List<UserVoucher> cusrvcr = new List<UserVoucher>();
            foreach (UserVoucher uv in UserVouchers)
            {
                if (uv.IsDeleted != true)
                {
                    cusrvcr.Add(uv);
                }
            }
            return cusrvcr;
        }

        public void Update(UserVoucher uservoucher)
        {
            if (uservoucher == null) return;
            var usrvcr = DB.UserVouchers.FirstOrDefault(u => u.ID == uservoucher.ID);
            if (usrvcr == null) return;
            DB.Entry(usrvcr).CurrentValues.SetValues(uservoucher);
            DB.SaveChanges();
        }
    }
}