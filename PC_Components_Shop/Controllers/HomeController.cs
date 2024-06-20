using PC_Components_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Data.SqlClient;

namespace PC_Components_Shop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(string filterCriteria, int? page, string sortByPrice)
        {
            ExamProjectDBEntities ExPe = new ExamProjectDBEntities();

            List<Product> Products = ExPe.Products.Where(w => w.ProductName.StartsWith(filterCriteria) || filterCriteria == null).ToList();
            IPagedList<Product> PagedProducts = Products.ToPagedList(page ?? 1,10);

            switch (sortByPrice)
            {
                case "standardPrice_asc":
                    PagedProducts = Products.OrderBy(o => o.StandardPrice).ToPagedList(page ?? 1, 10);
                    break;

                case "standardPrice_desc":
                    PagedProducts = Products.OrderByDescending(o => o.StandardPrice).ToPagedList(page ?? 1, 10);
                    break;

                case "default":
                    sortByPrice = null;
                    break;
            }
            ViewBag.CurrentSort = sortByPrice;
            ViewBag.PriceSortParm = sortByPrice == "standardPrice_asc" ? "standardPrice_asc" : "standardPrice_desc";
         
            return View(PagedProducts);  
        }
    }
}