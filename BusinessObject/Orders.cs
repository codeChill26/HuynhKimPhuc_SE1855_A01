﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public Orders(int customerID, int employeeID, DateTime orderDate)
        {
            CustomerID = customerID;
            EmployeeID = employeeID;
            OrderDate = orderDate;
        }
        public Orders()
        {
            // Default constructor for EF Core
        }
        public override string ToString()
        {
            return $"{OrderID}: Customer {CustomerID}, Employee {EmployeeID}, Order Date: {OrderDate.ToShortDateString()}";
        }

    }
}
