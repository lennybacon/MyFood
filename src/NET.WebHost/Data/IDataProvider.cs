using System;
using System.Collections.Specialized;

namespace lennybacon.MyFood.Data
{
  public interface IDataProvider
  {
    string ConnectionString { get; }

    object GetValue(
      string commandText,
      OrderedDictionary parameters = null);
    T GetValue<T>(
      string commandText,
      OrderedDictionary parameters = null);
    int ExecuteCommand(
      string commandText,
      OrderedDictionary parameters = null);
    void ProcessResult(
      Action<Func<string, object>> processRowAction,
      string commandText,
      OrderedDictionary parameters = null
      );
  }
}