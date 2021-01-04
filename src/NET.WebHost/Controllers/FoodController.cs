using lennybacon.MyFood.Data;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http;

namespace lennybacon.MyFood.Controllers
{
  public class FoodController : ApiController
  {
    private DataAccess _dataAccess = new DataAccess();

    // GET api/values
    public IEnumerable<string> Get()
    {
      var foods = new List<string>();

      _dataAccess[Constants.ConnectionStringName].ProcessResult(
        getReaderValue =>
        {
          foods.Add(getReaderValue("Name").ToString());
        },
        Properties.Resources.Food_Select_All);
      
      return foods;
    }

    // GET api/values/Zitrone
    public string Get(string id)
    {
      string foodName = null;
      _dataAccess[Constants.ConnectionStringName].ProcessResult(
       getReaderValue =>
       {
         foodName = getReaderValue("Name").ToString();
       },
       Properties.Resources.Food_Select_ByName,
       new OrderedDictionary { 
         {"Name", id }
       });

      return foodName;
    }

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
