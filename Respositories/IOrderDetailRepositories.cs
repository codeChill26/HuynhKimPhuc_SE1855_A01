using BusinessObject;
using System.Collections.Generic;

namespace Respositories
{
    public interface IOrderDetailRepositories
    {
        List<OrderDetails> GetOrderDetailsByOrderId(int orderId);
        void DeleteOrderDetail(int orderId, int productId);
    }
}