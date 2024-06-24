using PC_Components_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PC_Components_Shop.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult ShowForm()
        {
            ExamProjectDBEntities ExPe = new ExamProjectDBEntities();

            OrderViewData ordViewData = new OrderViewData();
            ordViewData.deliveryServiceList = ExPe.DeliveryServices.ToList();
            ordViewData.paymentMethodList = ExPe.PaymentMethods.ToList();
            ordViewData.productList = ExPe.Products.ToList();

            return View("CreateOrderPage", ordViewData);
        }
        
        /*
        [HttpPost]
        public ActionResult ValidateNInsertNewOrderData()
        {
            nastavi kasnije sa kreiranjem funkcionalnosti za insert ordera 
            ovaj deo bi mogao ustvari da uradis preko web API-a! just fyi
        }*/
    }
}