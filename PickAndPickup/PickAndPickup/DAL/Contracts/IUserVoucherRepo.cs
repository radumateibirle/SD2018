using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUserVoucherRepo
    {
        void Add(UserVoucher uservoucher);
        void Delete(int uservoucherID);
        void Update(UserVoucher uservoucher);
        List<UserVoucher> GetAll();
        List<UserVoucher> GetCurrent();
        UserVoucher GetByID(int ID);
    }
}
