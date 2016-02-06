using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(name: "Product", url: "{controller}/{action}/{id}");
            //routes.MapRoute()
            routes.MapRoute(name: "Default-Product", url: "", defaults: new { controller = "Product", action = "List", category = (string)null, page = 1 });
            routes.MapRoute(name: "Page", url: "{Page}", defaults: new { controller = "Product", action = "List", category = (string)null },constraints: new {page=@"\d+" });
            //routes.MapRoute(name: "", url: "{category}",defaults: new { controller="Product",category=(string)null,action="List",page=1 });
            routes.MapRoute(name: "Category", url: "{category}", defaults: new { controller = "Product", action = "List", page = 1 });
            routes.MapRoute(name: "Category-Page", url: "{category}/{page}", defaults: new { controller = "Product", action = "List" }, constraints: new { page=@"\d+"});
            routes.MapRoute(name: "Default", url: "{controller}/{action}");
                
        }
    }
}
