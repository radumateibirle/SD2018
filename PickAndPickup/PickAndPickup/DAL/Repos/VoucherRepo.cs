using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class VoucherRepo : IVoucherRepo
    {
        PickAndPickupEntities DB = new PickAndPickupEntities();
        public void Add(Voucher voucher)
        {
            if (voucher == null) return;
            DB.Vouchers.Add(voucher);
            DB.SaveChanges();
        }

        public void Delete(int voucherID)
        {
            if (voucherID < 1) return;
            var vcr = DB.Vouchers.FirstOrDefault(u => u.ID == voucherID);
            if (vcr == null) return;
            vcr.IsDeleted = true;
            DB.Entry(vcr).CurrentValues.SetValues(vcr);
            DB.SaveChanges();
        }

        public List<Voucher> GetAll()
        {
            return DB.Vouchers.ToList();
        }

        public Voucher GetByID(int ID)
        {
            return this.GetCurrent().FirstOrDefault(u => u.ID == ID);
        }

        public List<Voucher> GetCurrent()
        {
            var Vouchers = DB.Vouchers.ToList();
            List<Voucher> cvcr = new List<Voucher>();
            foreach (Voucher v in Vouchers)
            {
                if (v.IsDeleted != true)
                {
                    cvcr.Add(v);
                }
            }
            return cvcr;
        }

        public void Update(Voucher voucher)
        {
            if (voucher == null) return;
            var uvcr = DB.Vouchers.FirstOrDefault(u => u.ID == voucher.ID);
            if (uvcr == null) return;
            DB.Entry(uvcr).CurrentValues.SetValues(voucher);
            DB.SaveChanges();
        }
    }
}