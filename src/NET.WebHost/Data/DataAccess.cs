using System.Configuration;

namespace lennybacon.MyFood.Data
{
  /// <summary>
  /// Gived access to a data provider by mapping the connection string name with the configured connection string.
  /// </summary>
  public class DataAccess
  {
    /// <summary>
    /// Gets a <see cref="DataProvider"/> by mapping the connection string name with the configured connection string.
    /// </summary>
    /// <param name="connectionStringName">The name of the connection string in the config file.</param>
    /// <returns>A <see cref="DataProvider"/>.</returns>
    public DataProvider this[string connectionStringName] {
      get
      {
        var connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionStringName];
        if (connectionStringSetting == null)
        {
          throw new ConfigurationErrorsException(
            "Connection string with name `MyFood` is not configured.");
        }

        return new DataProvider(connectionStringSetting.ConnectionString);
      }
    }
  }
}