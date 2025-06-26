using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Customers( int customerID, string companyName, string contactName, string contactTitle, string address, string phone)
        {
            CustomerID = customerID;
            CompanyName = companyName;
            ContactName = contactName;
            ContactTitle = contactTitle;
            Address = address;
            Phone = phone;
        }
        public Customers()
        {
            // Default constructor for EF Core
        }
        public override string ToString()
        {
            return $"{CustomerID}: {CompanyName}, {ContactName}, {ContactTitle}, {Address}, {Phone}";
        }
    }
}
