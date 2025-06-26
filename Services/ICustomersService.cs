using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomersService
    {
        List<Customers> GetAllCustomers();
        void AddCustomers(Customers customers);
        void UpdateCustomers(Customers customers);
        void DeleteCustomers(int id);
        public Customers GetCustomerById(int id);
    }
}
