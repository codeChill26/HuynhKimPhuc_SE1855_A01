using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;

namespace Respositories
{
    public class EmployeesRepostitories : IEmployeesRepositories
    {
        EmployeeDAO employee = new EmployeeDAO();
        public Employees FindByUsernameAndPassword(string username, string password)
        {
            return employee.FindByUsernameAndPassword(username,password);
        }
        public List<Employees> GetAllEmployees()
        {
            return employee.GetAllEmployees();
        }
    }
}
