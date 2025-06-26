using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respositories
{
    public interface IProductRepositories
    {
        List<Products> GetAllProducts();
        void AddProducts(Products product);
        void UpdateProducts(Products product);
        void DeleteProducts(int id);
        Products GetProductById(int id);
    }
}
