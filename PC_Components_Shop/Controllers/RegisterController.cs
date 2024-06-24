using PC_Components_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PC_Components_Shop.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ExamProjectDBEntities ExPe = new ExamProjectDBEntities();
            var cities = ExPe.Cities;
            if(cities == null)
            {
                throw new Exception("cities are null!");
            }

            RegisterViewData regViewData = new RegisterViewData()
            {
                Account = new Account(),
                Address = new Address(),
                cityList = cities.ToList()
        };
           

            return View("Register", regViewData);
        }

        [HttpPost]
        public ActionResult SendAccountData(Account account)
        {
            if(ModelState.IsValid)
            {
                // Logiku za unos dodajem uskoro samo da istestiram validacije!
                return RedirectToAction("Index","Home");
            }
            return View("Register");
        }
    }
}