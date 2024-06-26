using PC_Components_Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PC_Components_Shop.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult CreateProductPage()
        {
            using (var ExPe = new ExamProjectDBEntities())
            {
                ProductViewData product = new ProductViewData()
                {
                    Product = new Product(),
                    ProductCategories = ExPe.ProductCategories.ToList()
                };

                return View("Product", product);
            }
        }

        [HttpPost]
        public ActionResult SendNewProductDataToDB(ProductViewData productData)
        {
            if(ModelState.IsValid)
            {
                using(var ExPe = new ExamProjectDBEntities())
                {
                    using (var tran = ExPe.Database.BeginTransaction())
                    {
                        try
                        {
                            Product NewProduct = new Product()
                            {
                                ProductName = productData.Product.ProductName,
                                ProductDescription = productData.Product.ProductDescription,
                                StandardPrice = productData.Product.StandardPrice,
                                QtyInStock = productData.Product.QtyInStock,
                                Fk_ProductCategoryID = productData.Product.Fk_ProductCategoryID,
                                ImagePaths = productData.Product.ImagePaths
                            };

                            ExPe.Products.Add(NewProduct);
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
                    }
                }   
            }

            using(var ExPe = new ExamProjectDBEntities())
            {
                productData.ProductCategories = ExPe.ProductCategories.ToList();
                return View("Product",productData);
            }
        }

        [HttpGet]
        public ActionResult UpdateProductPage(int id)
        {
            using(var ExPe = new ExamProjectDBEntities()) 
            {
                ProductViewData productUpdateView = new ProductViewData()
                {
                    Product = ExPe.Products.Where(w => w.ProductID == id).FirstOrDefault(),
                    ProductCategories = ExPe.ProductCategories.ToList()
                };
                return View("ProductUpdate", productUpdateView);
            }
        }

        [HttpPost]
        public ActionResult SendUpdatedProductDataToDB(ProductViewData productData)
        {
            if (ModelState.IsValid)  
            {
                using (var ExPe = new ExamProjectDBEntities())
                {
                    using (var tran = ExPe.Database.BeginTransaction())
                    {
                        try
                        {
                            var existingProduct = ExPe.Products.Where(w => w.ProductID == productData.Product.ProductID).FirstOrDefault();

                            if (existingProduct != null)
                            {
                                existingProduct.ProductName = productData.Product.ProductName;
                                existingProduct.ProductDescription = productData.Product.ProductDescription;
                                existingProduct.StandardPrice = productData.Product.StandardPrice;
                                existingProduct.QtyInStock = productData.Product.QtyInStock;
                                existingProduct.Fk_ProductCategoryID = productData.Product.Fk_ProductCategoryID;
                                existingProduct.ImagePaths = productData.Product.ImagePaths;
                            }
           
                            ExPe.SaveChanges();
                            tran.Commit();
                            return RedirectToAction("DetailsProductPage", "Product", new { id = existingProduct.ProductID});
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
                    }
                }
            }

            using (var ExPe = new ExamProjectDBEntities())
            {
                productData.ProductCategories = ExPe.ProductCategories.ToList();
                return View("ProductUpdate", productData);
            }
        }

        [HttpGet]
        public ActionResult DetailsProductPage(int id)
        {
            using (var ExPe = new ExamProjectDBEntities())
            {
                ProductViewData productDetailsView = new ProductViewData()
                {
                    Product = ExPe.Products.
                    Where(w => w.ProductID == id).FirstOrDefault()
                };     
                return View("ProductDetails", productDetailsView);
            }
        }

        [HttpGet]
        public ActionResult DeleteExistingProduct(int id)
        {
            using(var ExPe = new ExamProjectDBEntities())
            {
                using(var tran = ExPe.Database.BeginTransaction())
                {
                    try
                    {
                        var productForDelete = ExPe.Products.Where(w => w.ProductID == id).FirstOrDefault();
                        ExPe.Products.Remove(productForDelete);
                        ExPe.SaveChanges();
                        tran.Commit();
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception) 
                    {
                        tran.Rollback();
                        throw;
                    }
                }
               
               
            }
            
        }
    }
}