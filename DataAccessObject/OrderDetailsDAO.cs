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
    }
}