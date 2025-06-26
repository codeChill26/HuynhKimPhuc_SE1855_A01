using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Categories
    
        {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Categories(int categoryID, string categoryName, string description)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Description = description;
        }
        public override string ToString()
        {
            return $"{CategoryID}: {CategoryName}, {Description}";
        }
    }
}
