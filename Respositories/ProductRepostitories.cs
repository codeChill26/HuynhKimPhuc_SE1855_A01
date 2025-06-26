using BusinessObject;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public class ProductRepository : IProductRepositories
    {
        private readonly ProductDAO productDAO = new ProductDAO();

        public void AddProducts(Products product)
        {
            productDAO.AddProducts(product);
        }

        public void DeleteProducts(int id)
        {
            productDAO.DeleteProducts(id);
        }

        public List<Products> GetAllProducts()
        {
            return productDAO.GetAllProducts();
        }

        public Products GetProductById(int id)
        {
            return productDAO.GetProductById(id);
        }

        public void UpdateProducts(Products product)
        {
            productDAO.UpdateProducts(product);
        }
    }
}
