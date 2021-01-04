using System.Web.Http;

namespace lennybacon.MyFood
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web-API-Konfiguration und -Dienste

      // Web-API-Routen
      config.MapHttpAttributeRoutes();
      config.Formatters.Remove(config.Formatters.XmlFormatter);
      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
