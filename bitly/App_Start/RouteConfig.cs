using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bitly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute("Default",
                            "{controller}/{action}/{id}",
                            new { controller = "Home", action = "Index", id = "" },
                            new { controller = "home" });

            routes.MapRoute("Urls",
                          "{urlid}",
                          new { controller = "Home", action = "Click", urlid = "" });
        }
    }
}
