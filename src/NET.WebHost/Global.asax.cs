using System;
using System.Web.Http;

namespace lennybacon.MyFood
{
  public class Global : System.Web.HttpApplication
  {

    protected void Application_Start(object sender, EventArgs e)
    {
      GlobalConfiguration.Configure(WebApiConfig.Register);
    }

   
    protected void Application_Error(object sender, EventArgs e)
    {

    }

    
  }
}