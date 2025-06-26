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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void ManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow win = new CustomerWindow();
            win.ShowDialog();
        }

        private void ManageProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow win = new ProductWindow();
            win.ShowDialog();
        }

        private void ManageOrders_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow win = new OrderWindow();
            win.ShowDialog();
        }

        private void ViewReports_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow win = new ReportWindow();
            win.ShowDialog();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // hoặc chuyển về màn hình Login
        }
    }
}
