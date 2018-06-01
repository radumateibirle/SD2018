using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Repos
{
    public class OrderRepo : IOrderRepo
    {
        PickAndPickupEntities DB = new PickAndPickupEntities();
        public void Add(Order order)
        {
            if (order == null) return;
            DB.Orders.Add(order);
            DB.SaveChanges();
        }

        public void Delete(int orderID)
        {
            if (orderID < 1) return;
            var ord = DB.Orders.FirstOrDefault(u => u.ID == orderID);
            if (ord == null) return;
            ord.IsDeleted = true;
            DB.Entry(ord).CurrentValues.SetValues(ord);

            var OrderProduct = DB.OrderProducts.ToList();
            foreach (OrderProduct op in OrderProduct)
            {
                if (op.OrderID == orderID)
                {
                    op.IsDeleted = true;
                    DB.Entry(op).CurrentValues.SetValues(op);
                }
            }
            DB.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return DB.Orders.ToList();
        }

        public Order GetByID(int ID)
        {
            return this.GetCurrent().FirstOrDefault(o => o.ID == ID);
        }

        public List<Order> GetCurrent()
        {
            var Orders = DB.Orders.ToList();
            List<Order> co = new List<Order>();
            foreach (Order o in Orders)
            {
                if (o.IsDeleted != true)
                {
                    co.Add(o);
                }
            }
            return co;
        }

        public void Update(Order order)
        {
            if (order == null) return;
            var ord = DB.Orders.FirstOrDefault(u => u.ID == order.ID);
            if (ord == null) return;
            DB.Entry(ord).CurrentValues.SetValues(order);
            DB.SaveChanges();
        }

        public void updatePrice(int ID)
        {
            List<OrderProduct> ops = DB.OrderProducts.ToList();
            int sum = 0;
            foreach(OrderProduct op in ops)
            {
                if(op.OrderID == ID)
                {
                    Meal ml = DB.Meals.FirstOrDefault(m => m.ID == op.MealID);
                    if(ml != null)
                    {

                        sum += ((int) op.Quantity) * ((int)ml.Price);
                    }
                }
            }

            var ord = DB.Orders.FirstOrDefault(u => u.ID == ID);
            if (ord == null) return;
            ord.TotalPrice = sum;
            DB.Entry(ord).CurrentValues.SetValues(ord);
            DB.SaveChanges();
        }
    }
}