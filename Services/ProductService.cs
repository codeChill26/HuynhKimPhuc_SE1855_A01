using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Respositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositories productRepository;

        public ProductService()
        {
            productRepository = new ProductRepository();
        }

        public void AddProducts(Products product)
        {
            productRepository.AddProducts(product);
        }

        public List<Products> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Products GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        public void UpdateProducts(Products product)
        {
            productRepository.UpdateProducts(product);
        }

        public void DeleteProducts(int id)
        {
            productRepository.DeleteProducts(id);
        }
    }
}
