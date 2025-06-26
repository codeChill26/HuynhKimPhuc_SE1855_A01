using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; } 
        public int CategoriesID { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public Products(int productId, string productName, int supplierId, int categoriesId, string quantityPerUnit, double unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            ProductID = productId;
            ProductName = productName;
            SupplierID = supplierId;
            CategoriesID = categoriesId;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
        }
        public override string ToString()
        {
            return $"{ProductID}: {ProductName}, {SupplierID}, {CategoriesID}, {QuantityPerUnit}, {UnitPrice}, {UnitsInStock}, {UnitsOnOrder}, {ReorderLevel}, {Discontinued}";
        }
    }
}
