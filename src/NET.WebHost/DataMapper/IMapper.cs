using System;
using System.Collections.Specialized;

namespace lennybacon.MyFood.DataMapper
{
  public interface IMapper<TDataModel>
  {
    TDataModel MapFromDatabase(Func<string, object> getValue);
    OrderedDictionary MapFromObject(TDataModel dataModel);
  }
}