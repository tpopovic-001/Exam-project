using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PC_Components_Shop.Models
{
    public class OrderViewData
    {
        public List<DeliveryService> deliveryServiceList {  get; set; }    
        public List<PaymentMethod> paymentMethodList { get; set; }
        public List<Product> productList { get; set; }
    }
}