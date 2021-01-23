using lennybacon.MyFood.Data;
using lennybacon.MyFood.DataMapper;
using lennybacon.MyFood.DataModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Http;

namespace lennybacon.MyFood.Controllers
{
  public class FoodController : ApiController
  {
    private DataAccess _dataAccess = new DataAccess();
    private GenericMapper<Food> _mapper = new GenericMapper<Food>();

    // GET api/values
    public IEnumerable<Food> Get()
    {
      var foods = new List<Food>();

      _dataAccess[Constants.ConnectionStringName].ProcessResult(
        getReaderValue =>
        {
          foods.Add(_mapper.MapFromDatabase(getReaderValue));
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
