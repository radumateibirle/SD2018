using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class OrderProductRepo : IOrderProductRepo
    {
        PickAndPickupEntities DB = new PickAndPickupEntities();
        public void Add(OrderProduct orderproduct)
        {
            if (orderproduct == null) return;
            DB.OrderProducts.Add(orderproduct);
            DB.SaveChanges();
        }

        public void Delete(int orderproductID)
        {
            if (orderproductID < 1) return;
            var ordprd = DB.OrderProducts.FirstOrDefault(u => u.ID == orderproductID);
            if (ordprd == null) return;
            ordprd.IsDeleted = true;
            DB.Entry(ordprd).CurrentValues.SetValues(ordprd);
            DB.SaveChanges();
        }

        public List<OrderProduct> GetAll()
        {
            return DB.OrderProducts.ToList();
        }

        public OrderProduct GetByID(int ID)
        {
            return this.GetCurrent().FirstOrDefault(op => op.ID == ID);
        }

        public List<OrderProduct> GetCurrent()
        {
            var OrderProducts = DB.OrderProducts.ToList();
            List<OrderProduct> cop = new List<OrderProduct>();
            foreach (OrderProduct op in OrderProducts)
            {
                if (op.IsDeleted != true)
                {
                    cop.Add(op);
                }
            }
            return cop;
        }

        public void Update(OrderProduct orderproduct)
        {
            if (orderproduct == null) return;
            var ordprd = DB.OrderProducts.FirstOrDefault(u => u.ID == orderproduct.ID);
            if (ordprd == null) return;
            DB.Entry(ordprd).CurrentValues.SetValues(orderproduct);
            DB.SaveChanges();
        }
    }
}