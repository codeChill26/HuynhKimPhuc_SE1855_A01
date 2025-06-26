using BusinessObject;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class CustomersRepositories : ICustomersRepositories
    {
        CustomerDAO customerDAO = new CustomerDAO();
        public void AddCustomers(Customers customers)
        {
            customerDAO.AddCustomers(customers);
        }

        public void DeleteCustomers(int id)
        {
            customerDAO.DeleteCustomers(id);
        }

        public List<Customers> GetAllCustomers()
        {
            return customerDAO.GetAllCustomers();
        }

        public Customers GetCustomerById(int id)
        {
            return customerDAO.GetCustomerById(id);
        }

        public void UpdateCustomers(Customers customers)
        {
            customerDAO.UpdateCustomers(customers);
        }
    }
}
