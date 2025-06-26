using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Respositories;

namespace Services
{
    public class CustomerService : ICustomersService
    {
        private readonly ICustomersRepositories customerRepository;
        public CustomerService()
        {
            customerRepository = new CustomersRepositories();
        }

        public void AddCustomers(Customers customers)
        {
            customerRepository.AddCustomers(customers);
        }

        public List<Customers> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }
        public void UpdateCustomers(Customers customers)
        {
            customerRepository.UpdateCustomers(customers);
        }
        public Customers GetCustomerById(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        public void DeleteCustomers(int id)
        {
            customerRepository.DeleteCustomers(id);
        }
    }
}
