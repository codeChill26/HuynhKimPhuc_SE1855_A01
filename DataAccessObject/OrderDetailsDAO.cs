using BusinessObject;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObject
{
    public class OrderDetailDAO
    {
        private readonly AppDbContext context = new AppDbContext();

        public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            return context.OrderDetails.Where(o => o.OrderID == orderId).ToList();
        }
        public void DeleteOrderDetail(int orderId, int productId)
        {
            var orderDetail = context.OrderDetails
                .FirstOrDefault(o => o.OrderID == orderId && o.ProductID == productId);

            if (orderDetail != null)
            {
                context.OrderDetails.Remove(orderDetail);
                context.SaveChanges();
            }
        }
    }
}