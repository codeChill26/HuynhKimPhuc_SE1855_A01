using BusinessObject;
using Services;
using System.Windows;

namespace WPFApp
{
    public partial class MainWindow : Window
    {
        private readonly EmployeesService employeesService = new EmployeesService();
        private readonly CustomerService customerService = new CustomerService();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Employee login
        private void BtnEmployeeLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmpEmail.Text;
            string password = txtEmpPassword.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            var employee = employeesService.FindByUsernameAndPassword(email, password);
            if (employee != null)
            {
                MessageBox.Show($"Welcome {employee.Name}!");   
                new Admin().Show(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        // Customer login
        private void BtnCustomerLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = txtCustomerPhone.Text;
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter your phone number.");
                return;
            }

            var customer = customerService.GetAllCustomers()
                .FirstOrDefault(c => c.Phone == phone);

            if (customer != null)
            {
                MessageBox.Show($"Welcome {customer.ContactName}!");
                new Customer(customer).Show(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("Phone number not found.");
            }
        }
    }
}
