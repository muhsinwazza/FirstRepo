using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcAppFirst
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "Movies", "Movies/Index/{name}",
                new { controller = "Movies", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                "Employee", "{controller}/action/{name}",
                new { controller = "Employee", action = "Search", id = UrlParameter.Optional }
                );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Employee", action = "GetEmp", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                 name: "Process",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Process", action = "List", id = UrlParameter.Optional }
             );
            
           

            
        }
    }
}