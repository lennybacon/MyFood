using lennybacon.MyFood.Data;
using lennybacon.MyFood.DataMapper;
using lennybacon.MyFood.DataModel;
using System;
using System.Collections.Generic;
using System.Web;

namespace lennybacon.MyFood
{
  public class IISHandler1 : IHttpHandler
  {
    private DataAccess _dataAccess = new DataAccess();
    private GenericMapper<Food> _mapper = new GenericMapper<Food>();

    public bool IsReusable
    {
      get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
      if (context.Request.HttpMethod == "GET")
      {
        context.Response.ContentType = "text/html";
        context.Response.Headers.Add("X-MATTEO", "SUPER");
        context.Response.Write("<html>");
        context.Response.Write("<body>");
        context.Response.Write("<script>");
        context.Response.Write("var xhttp = new XMLHttpRequest();\n");
        context.Response.Write("xhttp.onreadystatechange = function() {\n");
        context.Response.Write("  if (this.readyState == 4 && this.status == 200){\n");
        context.Response.Write("    alert(this.responseText);\n");
        context.Response.Write("  }\n");
        context.Response.Write("};\n");
        context.Response.Write("xhttp.open('POST', 'IISHandler', true);\n");
        context.Response.Write("xhttp.setRequestHeader('Content-Type', 'application/json');\n");
        context.Response.Write("xhttp.send('{\"name\":\"Matteo\"}');\n");

        context.Response.Write("</script>");
        context.Response.Write("</body>");
        context.Response.Write("</html>");
        return;
      }

      if (context.Request.HttpMethod == "POST")
      {
        context.Response.ContentType = "application/json";
        context.Response.Write("{\"message\":\"OK\"}");
        return;
      }

      context.Response.StatusCode = 405;
     }
  }
}
