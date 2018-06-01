using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IOrderProductRepo
    {
        void Add(OrderProduct orderproduct);
        void Delete(int orderproductID);
        void Update(OrderProduct orderproduct);
        List<OrderProduct> GetAll();
        List<OrderProduct> GetCurrent();
        OrderProduct GetByID(int ID);
    }
}
