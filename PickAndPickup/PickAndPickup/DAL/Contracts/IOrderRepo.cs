using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IOrderRepo
    {
        void Add(Order order);
        void Delete(int orderID);
        void Update(Order order);
        List<Order> GetAll();
        List<Order> GetCurrent();
        Order GetByID(int ID);
        void updatePrice(int ID);
    }
}
