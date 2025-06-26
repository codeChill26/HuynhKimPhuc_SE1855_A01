using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject; 

namespace DataAccessObject
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-6QL24QC\\SQLEXPRESS04;Database=Lucy_SalesData;User Id=sa;Password=12345;TrustServerCertificate=True;MultipleActiveResultSets=True;"
);
        }
    }

}
