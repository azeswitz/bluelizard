using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;

namespace BlueLizard.Site
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Remove the XML formatting type
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            //Set the default JSON formatter to leveral camelCase rather than the default Pascal case
            var jsonType = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonType.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            //added to ignore circular DTO object references (e.g., Client -> Project -> Client
            var circularRefHandling = config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BlueLizardPersonApiZ",
                routeTemplate: "api/v1/bluelizard/person/{id}",
                defaults: new { controller = "BlueLizardPersonApi", id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
