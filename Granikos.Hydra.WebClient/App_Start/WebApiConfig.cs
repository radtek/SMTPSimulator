﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Granikos.Hydra.WebClient
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Controller Only
            config.Routes.MapHttpRoute(
                name: "ApiControllerOnly",
                routeTemplate: "api/{controller}"
            );

            // Controller with ID
            config.Routes.MapHttpRoute(
                name: "ApiControllerAndId",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^\d+$" } // Only integers 
            );

            // Controllers with Actions
            config.Routes.MapHttpRoute(
                name: "ApiControllerAndAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^\d+$" } // Only integers 
            );
        }
    }
}
