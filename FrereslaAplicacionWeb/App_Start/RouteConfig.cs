using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FrereslaAplicacionWeb
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
               name: "RutaAdmin",
               url: "{controller}/{action}/{nombre}",
               defaults: new { controller = "Admin", action = "Index", nombre = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "RutaCliente",
              url: "{controller}/{action}/{nombre}",
              defaults: new { controller = "Default1", action = "Index", id = UrlParameter.Optional }
          );
        }
    }
}