using BusinessObject;
using System.Collections.Generic;

namespace Services
{
    public interface IOrderDetailService
    {
        List<OrderDetails> GetOrderDetailsByOrderId(int orderId);
        void DeleteOrderDetail(int orderId, int productId);
    }
}
