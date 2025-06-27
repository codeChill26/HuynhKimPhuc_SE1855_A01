using BusinessObject;
using DataAccessObject;
using System.Collections.Generic;

namespace Respositories
{
    public class OrderDetailRepositories : IOrderDetailRepositories
    {
        private readonly OrderDetailDAO dao = new OrderDetailDAO();

        public List<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            return dao.GetOrderDetailsByOrderId(orderId);
        }
        public void DeleteOrderDetail(int orderId, int productId)
        {
            dao.DeleteOrderDetail(orderId, productId);
        }
    }
}
