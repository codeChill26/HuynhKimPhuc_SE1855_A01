using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ProductDAO
    {
        private readonly AppDbContext context = new AppDbContext();

        public List<Products> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Products GetProductById(int id)
        {
            return context.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public void AddProducts(Products product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProducts(Products product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProducts(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
