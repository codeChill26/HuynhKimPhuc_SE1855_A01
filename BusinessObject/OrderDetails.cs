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
        public double UnitPrice { get; set; }   
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public OrderDetails(int orderID, int productID, double unitPrice, int quantity, double discount)
        {
            OrderID = orderID;
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
