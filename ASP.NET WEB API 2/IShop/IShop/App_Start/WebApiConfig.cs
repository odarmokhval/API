﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using IShop.Filters;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace IShop
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                                                    new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                                                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/ostet-stream"));
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SearchRoute",
                routeTemplate: "api/{contorller}/{action}/{param}",
                defaults : new { 
                        param = RouteParameter.Optional 
                },
                constraints: new 
                { 
                    action = new AlphaRouteConstraint()
                });

            //config.Filters.Add(new ShopAuthentificationFilter());
        }
    }
}
