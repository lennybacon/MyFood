using lennybacon.MyFood.DataModel;
using System;
using System.Collections.Specialized;

namespace lennybacon.MyFood.DataMapper
{
  /// <summary>
  /// Maps colums of the database to properties of an object.
  /// </summary>
  public class FoodMapper : IMapper<Food>
  {
    public Food MapFromDatabase(Func<string, object> getValue)
    {
      var dataModel = new Food();
      dataModel.Id = (Guid)getValue("Id");
      dataModel.Created = (DateTime)getValue("Created");
      dataModel.CreatedBy = (string)getValue("CreatedBy");
      dataModel.Modified = (DateTime)getValue("Modified");
      dataModel.ModifiedBy = (string)getValue("ModifiedBy");
      dataModel.Name = (string)getValue("Name");
      dataModel.Carbohydrate = (decimal)getValue("Carbohydrate");
      dataModel.Protein = (decimal)getValue("Protein");
      dataModel.Fat = (decimal)getValue("Fat");
      dataModel.Fiber = (decimal)getValue("Fiber");
      dataModel.Sodium = (decimal)getValue("Sodium");
      dataModel.Sugar = (decimal)getValue("Sugar");
      dataModel.Cholesterol = (decimal)getValue("Cholesterol");
      dataModel.SaturatedFat = (decimal)getValue("SaturatedFat");
      dataModel.UnsaturatedFat = (decimal)getValue("UnsaturatedFat");
      dataModel.TransFat = (decimal)getValue("TransFat");
      dataModel.ServingSizeUnit = (string)getValue("ServingSizeUnit");
      dataModel.ServingSizeValue = (decimal)getValue("ServingSizeValue");


      return dataModel;
    }

    public OrderedDictionary MapFromObject(Food dataModel)
    {
      var parameters = new OrderedDictionary();
      parameters.Add("Id", dataModel.Id);
      //...
      throw new NotImplementedException("Damn, there is still stuff to do here...");
      return parameters;
    }
  }
}