using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public interface IEmployeesRepositories
    {
        public Employees FindByUsernameAndPassword(string username, string password);
    }
}
