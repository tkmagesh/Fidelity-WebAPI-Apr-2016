using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace _02_BugApiServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "myApp/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
            config.Routes.MapHttpRoute(
                name: "BugsByDate",
                routeTemplate: "myApp/Bugs/{year}/{month}/{day}",
                defaults: new { controller="Bugs", year = RouteParameter.Optional, month=RouteParameter.Optional, day = RouteParameter.Optional},
                constraints: new
                {
                    year = @"\d{0,4}",
                    month = @"\d{0,2}",
                    day = @"\d{0,2}"
                }
            );
            
        }
    }
}
