﻿using System.Web.Http;
using System.Web.Http.Cors;

namespace WeatherForcastApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","GET,POST,PUT");
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
