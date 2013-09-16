using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DataPal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ExtendedApiImagesInfo",
                routeTemplate: "api/xtnadswebapi/getimagesinfo",
                defaults: new { controller = "XTNAdsWebApi", action = "GetImagesInfo" }
            );

            config.Routes.MapHttpRoute(
                name: "ExtendedApiAdsInfo",
                routeTemplate: "api/xtnadswebapi/gettitlesonly",
                defaults: new { controller = "XTNAdsWebApi", action = "GetTitlesOnly" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}