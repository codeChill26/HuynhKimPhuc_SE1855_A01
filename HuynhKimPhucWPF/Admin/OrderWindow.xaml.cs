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

        public OrderWindow()
        {
            InitializeComponent();

            // Khởi tạo service
            orderService = new OrderService();
            customerService = new CustomerService();
            employeesService = new EmployeesService();

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
            if (cbCustomerID.SelectedValue == null || cbEmployeeID.SelectedValue == null)
            {
                MessageBox.Show("Please select both CustomerID and EmployeeID.");
                return;
            }

            int customerId = Convert.ToInt32(cbCustomerID.SelectedValue);
            int employeeId = Convert.ToInt32(cbEmployeeID.SelectedValue);
            DateTime orderDate = dpOrderDate.SelectedDate ?? DateTime.Now;

            var order = new Orders
            {
                CustomerID = customerId,      // Đây là string
                EmployeeID = employeeId,      // Đây là int
                OrderDate = orderDate
            };

            orderService.AddOrder(order);
            MessageBox.Show("Order added successfully.");
            DisplayAllOrders();
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
                orderService.DeleteOrder(selectedOrder.OrderID);
                MessageBox.Show("Order deleted.");
                DisplayAllOrders();
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
