using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace lennybacon.MyFood.Data
{
  /// <summary>
  /// Gived access to a database and its tables.
  /// </summary>
  public class DataProvider : IDataProvider
  {
    /// <summary>
    /// Inistantiates a new instance of the data provider.
    /// </summary>
    /// <param name="connectionString"></param>
    public DataProvider(string connectionString)
    {
      ConnectionString = connectionString;
    }

    /// <summary>
    /// Gets the connection string.
    /// </summary>
    public string ConnectionString { get; }

    public object GetValue(string commandText, OrderedDictionary parameters = null)
    {
      return ProcessCommand(cmd => cmd.ExecuteScalar(), commandText, parameters);
    }


    public T GetValue<T>(string commandText, OrderedDictionary parameters = null)
    {
      return (T)ProcessCommand(cmd => cmd.ExecuteScalar(),commandText, parameters);
    }

    /// <summary>
    /// Executes a non-query command but does not care about connection and command handling.
    /// </summary>
    public int ExecuteCommand(string commandText, OrderedDictionary parameters = null)
    {
      return ProcessCommand(cmd => cmd.ExecuteNonQuery(), commandText, parameters);
    }

    public void ProcessResult(Action<Func<string, object>> processRowAction, string commandText, OrderedDictionary parameters = null)
    {
      ProcessCommand(cmd =>
                     {
                       using (var reader = cmd.ExecuteReader())
                       {
                         while (reader.Read())
                         {
                           processRowAction(
                               new Func<string, object>(name => reader[name])
                             );
                         }
                       }
                       return true;
                     },
                     commandText, parameters);
    }


    /// <summary>
    /// Handles the command and connection while not knowing what is done with the command.
    /// </summary>
    private T ProcessCommand<T>(Func<SqlCommand, T> action, string commandText, OrderedDictionary parameters = null)
    {
      using (var connection = new SqlConnection(ConnectionString))
      {
        connection.Open();
        using (var command = connection.CreateCommand())
        {
          command.CommandText = commandText;

          AddParameters(parameters, command);

          return action(command);
        }
      }
    }

    private static void AddParameters(OrderedDictionary parameters, SqlCommand command)
    {
      if (parameters != null)
      {
        foreach (DictionaryEntry item in parameters)
        {
          if(!(item.Key is string parameterName))
          {
            throw new ArgumentException("The parameters dictionary contains an entry which has a key that is not of type string.");
          }
          command.Parameters.AddWithValue(parameterName, item.Value);
        }
      }
    }
  }
}