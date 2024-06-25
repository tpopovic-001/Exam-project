using PC_Components_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCrypt.Net;
using System.Data.Entity.Validation;
using System.Text.RegularExpressions;

namespace PC_Components_Shop.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ExamProjectDBEntities ExPe = new ExamProjectDBEntities();
            var cities = ExPe.Cities;
            if (cities == null)
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
        public ActionResult SendAccountData(RegisterViewData regViewData)
        {
           
            if (ModelState.IsValid)
            {
                using (var ExPe = new ExamProjectDBEntities())
                {
                    using (var tran = ExPe.Database.BeginTransaction())
                    {
                        try
                        {
                            var newAccount = new Account
                            {
                                FirstName = regViewData.Account.FirstName,
                                LastName = regViewData.Account.LastName,
                                EmailAddress = regViewData.Account.EmailAddress,
                                DOB = regViewData.Account.DOB,
                                UserName = regViewData.Account.UserName,
                                Password = BCrypt.Net.BCrypt.HashPassword(regViewData.Account.Password,workFactor: 11),
                                DateOfRegistration = DateTime.Now,
                                Fk_AccountTypeID = 2,
                                Address = new Address
                                {
                                    StreetName = regViewData.Account.Address.StreetName,
                                    StreetNumber = regViewData.Account.Address.StreetNumber,
                                    ApartmentNumber = regViewData.Account.Address.ApartmentNumber,
                                    Fk_City = regViewData.SelectedBillingAddressCityID
                                },
                                Address1 = new Address
                                {
                                    StreetName = regViewData.Account.Address1.StreetName,
                                    StreetNumber = regViewData.Account.Address1.StreetNumber,
                                    ApartmentNumber = regViewData.Account.Address1.ApartmentNumber,
                                    Fk_City = regViewData.SelectedShippingAddressCityID
                                }
                            };

                            ExPe.Accounts.Add(newAccount);
                            ExPe.SaveChanges();
                            tran.Commit();
                            return RedirectToAction("Index", "Home");
                        }
                        catch (DbEntityValidationException ex)
                        {
                            foreach (var eve in ex.EntityValidationErrors)
                            {
                                Console.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    Console.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                                }
                            }
                            tran.Rollback();   
                        }                      
                    };
                }                  
            }

            using(var ExPe = new ExamProjectDBEntities())
            {
                var cities = ExPe.Cities;
                if (cities == null)
                {
                    throw new Exception("cities are null!");
                }
                regViewData.cityList = cities.ToList();
                return View("Register", regViewData);
            }
        }
    }
}
   