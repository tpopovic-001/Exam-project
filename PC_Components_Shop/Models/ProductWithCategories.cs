using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PC_Components_Shop.Models
{
    public class ProductWithCategories
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal StandardPrice { get; set; }
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}