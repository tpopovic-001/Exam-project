using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace PC_Components_Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Register",
              url: "{controller}/{action}",
              defaults: new { controller = "Register", action = "Index" }
          );

            routes.MapRoute(
             name: "Login",
             url: "{controller}/{action}",
             defaults: new { controller = "Login", action = "Index" }
         );

         routes.MapRoute(
         name: "Logout",
         url: "{controller}/{action}",
         defaults: new { controller = "Login", action = "Logout" }
        );

        routes.MapRoute(
        name: "CreateProduct",
        url: "{controller}/{action}",
        defaults: new { controller = "Product", action = "CreateProductPage" }
        );

       routes.MapRoute(
       name: "UpdateProduct",
       url: "{controller}/{action}",
       defaults: new { controller = "Product", action = "UpdateProductPage" }
       );

      routes.MapRoute(
      name: "DetailProduct",
      url: "{controller}/{action}",
      defaults: new { controller = "Product", action = "DetailsProductPage" }
      );

     routes.MapRoute(
     name: "SendUpdatedProduct",
     url: "{controller}/{action}/{id}",
     defaults: new { controller = "Product", action = "SendUpdatedProductDataToDB", id = UrlParameter.Optional }
     );

        }
    }
}
