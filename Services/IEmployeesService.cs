using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeesService
    {
        public Employees FindByUsernameAndPassword(string username, string password);
        List<Employees> GetAllEmployees();
    }
}
