using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PickAndPickup
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Admin_default1",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional }, 
                new[] { "PickAndPickup.Areas.Admin.Controllers" }
            ).DataTokens.Add("area", "Admin");

            routes.MapRoute(
                "Chef_default1",
                "Chef/{controller}/{action}/{id}",
                new { controller = "Chef", action = "Index", id = UrlParameter.Optional },
                new[] { "PickAndPickup.Areas.Chef.Controllers" }
            ).DataTokens.Add("area", "Chef");

            routes.MapRoute(
                "User_default1",
                "User/{controller}/{action}/{id}",
                new { controller = "User", action = "Index", id = UrlParameter.Optional },
                new[] { "PickAndPickup.Areas.User.Controllers" }
            ).DataTokens.Add("area", "User");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PickAndPickup.Controllers" }
            );
        }
    }
}
