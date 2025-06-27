using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class EmployeeDAO
    {
        public AppDbContext context = new AppDbContext();

        public Employees FindByUsernameAndPassword(string username, string password)
        {
            return context.Employees.FirstOrDefault(e => e.UserName ==username && e.Password ==password);
        }

        public List<Employees> GetAllEmployees()
        {
            return context.Employees.ToList();
        }
        
    }
}
