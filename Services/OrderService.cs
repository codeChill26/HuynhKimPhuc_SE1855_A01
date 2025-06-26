using BusinessObject;
using Respositories;
using System.Collections.Generic;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService()
        {
            orderRepository = new OrderRepository();
        }

        public void AddOrder(Orders order)
        {
            orderRepository.AddOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            orderRepository.DeleteOrder(orderId);
        }

        public Orders GetOrderById(int orderId)
        {
            return orderRepository.GetOrderById(orderId);
        }

        public List<Orders> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }
    }
}
