using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PC_Components_Shop.Models
{
    public class RegisterViewData
    {
        public Account Account { get; set; }
        public Address Address { get; set; }
        public List<City> cityList {  get; set; }
        [Required(ErrorMessage ="Billing address city is required field!")]
        [Range(1,92,ErrorMessage ="City for Billing Address is not selected!")]
        public int SelectedBillingAddressCityID { get; set; }
        [Required(ErrorMessage ="Shipping address city is required field!")]
        [Range(1, 92, ErrorMessage = "City for Shipping Address is not selected!")]
        public int SelectedShippingAddressCityID { get; set; } 
      
    }
}