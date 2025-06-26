using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public Employees(int employeeID, string name, string userName, string password, string jobTitle)
        {
            EmployeeID = employeeID;
            Name = name;
            UserName = userName;
            Password = password;
            JobTitle = jobTitle;
        }
        public override string ToString()
        {
            return $"{EmployeeID}: {Name}, {UserName}, {JobTitle}";
        }
    }
}
