using PC_Components_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace PC_Components_Shop.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            LoginViewData loginData = new LoginViewData();
            return View("Login",loginData);
        }

        [HttpPost]
        public ActionResult CredentialCheck(LoginViewData credParameters)
        {
            using (var ExPe = new ExamProjectDBEntities())
            {
                var credentialsFromDB = ExPe.Accounts.Where
                    ( w => w.UserName == credParameters.Username        
                    ).Select(s => new LoginViewData
                    { 
                        UserId = s.AccountID,
                        Username = s.UserName,
                        Password = s.Password,
                        UserType = s.Fk_AccountTypeID

                    }).FirstOrDefault();
                    
                if( credParameters.Username == null) 
                {
                    ModelState.AddModelError("Username", "Username field is required and it must be populated with existing username!");
                }
                else if(credParameters.Password == null)
                {
                    ModelState.AddModelError("Password", "Password field is required and it must be populated with a password of an existing user!");
                }
                else if (credentialsFromDB == null || credentialsFromDB.Username == null)
                {
                    ModelState.AddModelError("Username", "User with this username doesn't exist!");
                }
                else if (credentialsFromDB.Password != null)
                {
                    bool Passwordcheck = BCrypt.Net.BCrypt.Verify(credParameters.Password, credentialsFromDB.Password);

                    if (!Passwordcheck)
                    {
                        ModelState.AddModelError("Password", "Incorrect password! Try again!");
                    }
                }

                if(!ModelState.IsValid)
                {
                    return View("Login",credParameters);
                }

                Session["AccountID"] = credentialsFromDB.UserId;
                Session["AccountType"] = credentialsFromDB.UserType;

                return RedirectToAction("Index","Home");    
            }       
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}