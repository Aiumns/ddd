using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPannel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Home",
            //    url: "Home/{action}",
            //    defaults: new { controller = "Home", action = "Index" }
            //  );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Signup", id = UrlParameter.Optional }
            );

           // routes.MapRoute(
           //    name: "Default",
           //    url: "{controller}/{action}/{id}",
           //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           //);
        }
    }
}
