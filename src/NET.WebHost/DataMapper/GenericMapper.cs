using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;

namespace lennybacon.MyFood.DataMapper
{
  public class GenericMapper<T>
    : IMapper<T>
    where T: class, new()
  {
    private static readonly Type _s_dataType = typeof(T);
    private static PropertyInfo[] _s_properties = 
      _s_dataType
      .GetProperties()
      .Where(
        p => 
        p.CanWrite 
        && p.CanRead 
        && p.GetIndexParameters().Length == 0
        && p.GetCustomAttribute<ColumnAttribute>() != null)
      .ToArray();

    public T MapFromDatabase(Func<string, object> getValue)
    {
      var dataModel = new T();
      foreach (var property in _s_properties)
      {
        property.SetValue(dataModel, getValue(GetColumnName(property)));
      }
      return dataModel;
    }

    public OrderedDictionary MapFromObject(T dataModel)
    {
      var parameters = new OrderedDictionary();
      foreach (var property in _s_properties)
      {
        parameters[GetColumnName(property)] = property.GetValue(dataModel);
      }
      return parameters;
    }

    private string GetColumnName(PropertyInfo property)
    {
      var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
      if(columnAttribute == null)
      {
        throw new InvalidOperationException("Da hell, what happend?");
      }

      return columnAttribute.Name;
    }
  }
}