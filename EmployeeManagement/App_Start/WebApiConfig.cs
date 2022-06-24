using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // Web API configuration and services
            EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors(cors);


            // config.AddCors(cors => cors.AddPolicy("MyPolicy"), builder => {
            //    builder.AllowAnyOrigin().Allow
            // });



            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });



            


            // Set JSON formatter as default one and remove XmlFormatter

          //  var jsonFormatter = config.Formatters.JsonFormatter;
          //  jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
          //  config.Formatters.Remove(config.Formatters.XmlFormatter);
           // jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;


            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;




        }
    }
}
