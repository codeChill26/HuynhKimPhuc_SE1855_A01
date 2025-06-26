using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Services;
using BusinessObject;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EmployeesService employeesService = new EmployeesService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Employees employee = employeesService.FindByUsernameAndPassword(username, password);
            if (employee != null)
            {
                Admin adminWindow = new Admin();
                adminWindow.Show(); 
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }

        
    }
}