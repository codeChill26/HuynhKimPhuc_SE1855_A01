using BusinessObject;
using Services;
using System.Collections.Generic;
using System.Windows;

namespace WPFApp
{
    public partial class OrderDetailWindow : Window
    {
        private readonly OrderDetailService detailService = new OrderDetailService();

        public OrderDetailWindow(int orderId)
        {
            InitializeComponent();
            LoadOrderDetails(orderId);
        }

        private void LoadOrderDetails(int orderId)
        {
            List<OrderDetails> details = detailService.GetOrderDetailsByOrderId(orderId);
            lvOrderDetails.ItemsSource = details;
        }
    }
}
