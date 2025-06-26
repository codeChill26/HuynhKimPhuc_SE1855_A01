using BusinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        CustomerService customerService;
        public CustomerWindow()
        {
            InitializeComponent();
            DisplayAllCustomers();
        }

        private void DisplayAllCustomers()
        {
            customerService = new CustomerService();
            List<Customers> customers = customerService.GetAllCustomers();
            lvCustomers.ItemsSource = customers;
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customers
            {
                
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };

            customerService.AddCustomers(customer);
            DisplayAllCustomers();
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Lấy khách hàng được chọn từ ListView
            var selectedCustomer = lvCustomers.SelectedItem as Customers;

            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            // Lấy đúng ID
            int customerId = selectedCustomer.CustomerID;

            // Tận dụng hàm GetCustomerById nếu bạn muốn xác nhận lại từ DB (tùy)
            var customer = customerService.GetCustomerById(customerId);

            if (customer == null)
            {
                MessageBox.Show("Customer not found in database.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                customerService.DeleteCustomers(customerId);
                DisplayAllCustomers();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = lvCustomers.SelectedItem as Customers;
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to edit.");
                return;
            }

            // Gán lại thông tin mới từ TextBox
            selectedCustomer.CompanyName = txtCompanyName.Text;
            selectedCustomer.ContactName = txtContactName.Text;
            selectedCustomer.ContactTitle = txtContactTitle.Text;
            selectedCustomer.Address = txtAddress.Text;
            selectedCustomer.Phone = txtPhone.Text;

            // Gọi Service để cập nhật
            customerService.UpdateCustomers(selectedCustomer);
            DisplayAllCustomers();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            // Gọi lại GetAllCustomers rồi lọc
            var allCustomers = customerService.GetAllCustomers();

            var result = allCustomers
                .Where(c => c.CompanyName != null && c.CompanyName.ToLower().Contains(keyword))
                .ToList();

            lvCustomers.ItemsSource = result;
        }


    }
}
