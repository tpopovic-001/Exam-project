using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PC_Components_Shop.Models
{
    public class ProductViewData
    {
        public Product Product { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    
    }
}