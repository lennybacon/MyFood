using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace lennybacon.MyFood.Controllers
{
  public class FoodController : ApiController
  {
    // GET api/values
    public IEnumerable<string> Get()
    {
      var foods = new List<string>();

      var connectionStringSetting = ConfigurationManager.ConnectionStrings["MyFood"];
      if (connectionStringSetting == null)
      {
        throw new ConfigurationErrorsException(
          "Connection string with name `MyFood` is not configured.");
      }

      using (var connection = new SqlConnection(connectionStringSetting.ConnectionString))
      {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
          command.CommandText = @"SELECT [Name] FROM [dbo].[Food]";

          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              foods.Add(reader["Name"].ToString());
            }
          }
        }
      }


      return foods;
    }

    //// GET api/values/5
    //public string Get(int id)
    //{
    //  return "value";
    //}

    //// POST api/values
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/values/5
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/values/5
    //public void Delete(int id)
    //{
    //}
  }
}
