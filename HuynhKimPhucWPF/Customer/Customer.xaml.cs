using BusinessObject;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPFApp
{
    public partial class Customer : Window
    {
        private readonly CustomerService customerService = new CustomerService();
        private readonly OrderService orderService = new OrderService();
        private Customers currentCustomer;

        public Customer(Customers customer)
        {
            InitializeComponent();
            currentCustomer = customer;

            LoadCustomerInfo();
            LoadOrderHistory();
        }

        private void LoadCustomerInfo()
        {
            txtCompanyName.Text = currentCustomer.CompanyName;
            txtContactName.Text = currentCustomer.ContactName;
            txtContactTitle.Text = currentCustomer.ContactTitle;
            txtAddress.Text = currentCustomer.Address;
            txtPhone.Text = currentCustomer.Phone;
        }

        private void LoadOrderHistory()
        {
            var orders = orderService.GetAllOrders()
                .Where(o => o.CustomerID == currentCustomer.CustomerID)
                .ToList();

            lvOrderHistory.ItemsSource = orders;
        }

        private void BtnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            currentCustomer.CompanyName = txtCompanyName.Text;
            currentCustomer.ContactName = txtContactName.Text;
            currentCustomer.ContactTitle = txtContactTitle.Text;
            currentCustomer.Address = txtAddress.Text;
            currentCustomer.Phone = txtPhone.Text;

            customerService.UpdateCustomers(currentCustomer);

            MessageBox.Show("Profile updated successfully.");
        }
    }
}
