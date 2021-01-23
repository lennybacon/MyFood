using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lennybacon.MyFood
{
  /// <summary>
  /// Zusammenfassungsbeschreibung für Handler1
  /// </summary>
  public class Handler1 : IHttpHandler
  {

    public void ProcessRequest(HttpContext context)
    {
      context.Response.ContentType = "text/plain";
      context.Response.Write("Hello World Handler1");
    }

    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}