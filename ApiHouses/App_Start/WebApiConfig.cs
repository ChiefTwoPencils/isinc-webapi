using ApiHouses.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace ApiHouses
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Configure media type mapping through query string
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("fmt", "json", "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("fmt", "xml", "application/xml"));

            // Configure a media type mapping through custom element in request header
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new RequestHeaderMapping("X-MyMedia", "json",
                    StringComparison.OrdinalIgnoreCase, false,
                    "application/json"));
            config.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new RequestHeaderMapping("X-MyMedia", "xml",
                    StringComparison.OrdinalIgnoreCase, false,
                    "application/xnk"));
            
            foreach (MediaTypeFormatter fmt in config.Formatters)
            {
                Debug.WriteLine(fmt.GetType().Name);
                Debug.WriteLine($"    CanReadType: {fmt.CanReadType(typeof(House))}");
                Debug.WriteLine($"    CanWriteType: {fmt.CanWriteType(typeof(House))}");
                Debug.WriteLine("    Media Types: " + String.Join(", ", fmt.SupportedMediaTypes));
            }
        }
    }
}
