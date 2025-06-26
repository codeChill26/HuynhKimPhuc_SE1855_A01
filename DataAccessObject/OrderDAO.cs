using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class OrderDAO
    {
        private readonly AppDbContext context = new AppDbContext();

        public void AddOrder(Orders order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        public Orders GetOrderById(int orderId)
        {
            return context.Orders.FirstOrDefault(o => o.OrderID == orderId);
        }

        public List<Orders> GetAllOrders()
        {
            return context.Orders.ToList();
        }
    }
}
