using BusinessObject;
using System.Collections.Generic;

namespace Services
{
    public interface IOrderDetailService
    {
        List<OrderDetails> GetOrderDetailsByOrderId(int orderId);
    }
}
