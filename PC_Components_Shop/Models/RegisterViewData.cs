using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PC_Components_Shop.Models
{
    public class RegisterViewData
    {
        public Account Account { get; set; }
        public Address Address { get; set; }
        public List<City> cityList {  get; set; }
      
    }
}