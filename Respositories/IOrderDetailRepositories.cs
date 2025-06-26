using BusinessObject;
using System.Collections.Generic;

namespace Respositories
{
    public interface IOrderDetailRepositories
    {
        List<OrderDetails> GetOrderDetailsByOrderId(int orderId);

    }
}