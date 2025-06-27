using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPFApp
{
    public partial class OrderWindow : Window
    {
        private readonly OrderService orderService;
        private readonly CustomerService customerService;
        private readonly EmployeesService employeesService;
        private readonly OrderDetailService orderDetailService;

        public OrderWindow()
        {
            InitializeComponent();
            orderService = new OrderService();
            customerService = new CustomerService();
            employeesService = new EmployeesService();
            orderDetailService = new OrderDetailService();

            LoadComboBoxes();
            DisplayAllOrders();
        }

        private void LoadComboBoxes()
        {
            cbCustomerID.ItemsSource = customerService.GetAllCustomers();
            cbCustomerID.DisplayMemberPath = "CustomerID";
            cbCustomerID.SelectedValuePath = "CustomerID";

            cbEmployeeID.ItemsSource = employeesService.GetAllEmployees();
            cbEmployeeID.DisplayMemberPath = "EmployeeID";
            cbEmployeeID.SelectedValuePath = "EmployeeID";
        }

        private void DisplayAllOrders()
        {
            var orders = orderService.GetAllOrders();
            lvOrders.ItemsSource = orders;
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var customerId = cbCustomerID.SelectedValue;
            var employeeId = cbEmployeeID.SelectedValue;
            var orderDate = dpOrderDate.SelectedDate ?? DateTime.Now;

            if (customerId ==null || employeeId == null)
            {
                MessageBox.Show("Please select both CustomerID and EmployeeID.");
                return;
            }

            var order = new Orders
            {
                CustomerID = Convert.ToInt32(customerId),
                EmployeeID = Convert.ToInt32(employeeId),
                OrderDate = orderDate
            };

            try
            {
                orderService.AddOrder(order);
                MessageBox.Show("Order added successfully.");
                DisplayAllOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add order: " + ex.Message);
            }
        }

        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = lvOrders.SelectedItem as Orders;
                
            if (selectedOrder == null)
            {
                MessageBox.Show("Please select an order to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this order?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    var orderDetails = orderDetailService.GetOrderDetailsByOrderId(selectedOrder.OrderID);
                    foreach (var detail in orderDetails)
                    {
                        orderDetailService.DeleteOrderDetail(detail.OrderID, detail.ProductID);
                    }

                    orderService.DeleteOrder(selectedOrder.OrderID);
                    MessageBox.Show("Order deleted successfully.");
                    DisplayAllOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot delete this order. It may contain order details.\n" + ex.Message,
                                    "Delete Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnViewOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = lvOrders.SelectedItem as Orders;
            if (selectedOrder != null)
            {
                var detailWindow = new OrderDetailWindow(selectedOrder.OrderID);
                detailWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order to view details.");
            }
        }
    }
}
