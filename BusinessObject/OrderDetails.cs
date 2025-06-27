using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }   
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public OrderDetails(int productID, decimal unitPrice, int quantity, decimal discount)
        {
            ProductID = productID;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
        }
        public override string ToString()
        {
            return $"{OrderID}: Product {ProductID}, Quantity: {Quantity}, Unit Price: {UnitPrice:C}, Discount: {Discount:P}";
        }
    }
}
