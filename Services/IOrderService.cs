using BusinessObject;
using System.Collections.Generic;

namespace Services
{
    public interface IOrderService
    {
        void AddOrder(Orders order);
        void DeleteOrder(int orderId);
        Orders GetOrderById(int orderId);
        List<Orders> GetAllOrders();
    }
}
