using BusinessObject;
using System.Collections.Generic;

namespace Respositories
{
    public interface IOrderRepository
    {
        void AddOrder(Orders order);
        void DeleteOrder(int orderId);
        Orders GetOrderById(int orderId);
        List<Orders> GetAllOrders();
    }
}
