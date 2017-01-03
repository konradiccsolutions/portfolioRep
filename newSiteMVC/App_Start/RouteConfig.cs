using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace newSiteMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{file}.html");
            routes.IgnoreRoute("{file}.php");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Page",
              url: "Page/{pageId}",
              defaults: new { controller = "Pages", action = "LoadPageContent", pageId = UrlParameter.Optional, Id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "News",
               url: "Page/{pageId}/News/{id}",
               defaults: new { controller = "Pages", action = "LoadPageContent", pageId = UrlParameter.Optional, Id = UrlParameter.Optional }
           );

           
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
