using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IVoucherRepo
    {
        void Add(Voucher voucher);
        void Delete(int voucherID);
        void Update(Voucher voucher);
        List<Voucher> GetAll();
        List<Voucher> GetCurrent();
        Voucher GetByID(int ID);
    }
}
