using lennybacon.MyFood.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;

namespace lennybacon.MyFood
{
  /// <summary>
  /// Zusammenfassungsbeschreibung für Handler1
  /// </summary>
  public class SqlHandler : IHttpHandler
  {
    private static readonly Type _s_tableAttribute = typeof(TableAttribute);
    private static readonly Type _s_nullable = typeof(Nullable<>);

    public void ProcessRequest(HttpContext context)
    {
      context.Response.ContentType = "text/plain";

      var tableTypes =
        Assembly.GetExecutingAssembly()
        .GetTypes().Where(p => p.GetCustomAttributes(_s_tableAttribute, true).Length > 0)
        .ToArray();
      context.Response.Write("-- SQL Statements to creat the database schema :-)\r\n\r\n");

      context.Response.Write("USE[MyFood];\r\n");
      context.Response.Write("GO\r\n\r\n");

      foreach (var tableType in tableTypes)
      {
        var tableName = tableType.GetCustomAttribute<TableAttribute>().Name;
        var keyAttribute =
          tableType
            .GetProperties()
            .Where(p => p.GetCustomAttribute<KeyAttribute>() != null)
            .Select(p => p.GetCustomAttribute<ColumnAttribute>())
            .Where(a => a != null)
            .FirstOrDefault();

        var columnsAndAttributes =
          tableType
            .GetProperties()
            .Select(p => new
            {
              Property = p,
              Attribute = p.GetCustomAttribute<ColumnAttribute>(),
              Generated = p.GetCustomAttribute<DatabaseGeneratedAttribute>(),
              DefaultValue = p.GetCustomAttribute<DefaultValueAttribute>()
            })
            .Where(a => a.Attribute != null)
            .ToArray();

        context.Response.Write("IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='" + tableName + "' and xtype='U')\r\n");
        context.Response.Write("  BEGIN\r\n");
        context.Response.Write("    CREATE TABLE [dbo].[" + tableName + "]\r\n");
        context.Response.Write("    (\r\n");

        for (int i = 0; i < columnsAndAttributes.Length; i++)
        {
          var column = columnsAndAttributes[i];

          if (keyAttribute.Equals(column.Attribute))
          {
            if (column.Property.PropertyType == typeof(Guid))
            {
              context.Response.Write("      [" + column.Attribute.Name + "] uniqueidentifier ROWGUIDCOL NOT NULL CONSTRAINT [ncu_" + tableName + "By" + column.Attribute.Name + "] DEFAULT newsequentialid()");
            }
            else
            {
              context.Response.Write("      [" + column.Attribute.Name + "] bigint NOT NULL CONSTRAINT [ncu_" + tableName + "By" + column.Attribute.Name + "] DEFAULT IDENTITY(1,1)");
            }

            if(i+1 < columnsAndAttributes.Length)
            {
              context.Response.Write(",\r\n");
            }
            else
            {
              context.Response.Write("\r\n");
            }
            continue;
          }

          if (column.Generated != null)
          {
            if (column.Property.PropertyType == typeof(DateTime))
            {
              context.Response.Write("      [" + column.Attribute.Name + "] datetime2(3) NOT NULL DEFAULT (SYSUTCDATETIME())");
            }
            else
            {
              context.Response.Write("      [" + column.Attribute.Name + "] varchar(312) NOT NULL DEFAULT (SYSTEM_USER)");
            }

            if (i + 1 < columnsAndAttributes.Length)
            {
              context.Response.Write(",\r\n");
            }
            else
            {
              context.Response.Write("\r\n");
            }
            continue;
          }

          var isNullable = true;

          if (column.Property.PropertyType.IsValueType)
          {
            // for value types to be nullable the Nullable<> type should wrap the value type.
            isNullable =
              column.Property.PropertyType.GetGenericArguments().Length != 0
              && _s_nullable == column.Property.PropertyType.GetGenericTypeDefinition();
          }
          else
          {
            // for reference types nullable is set when NO required attribute is found.
            isNullable = column.Property.GetCustomAttribute<RequiredAttribute>() == null;
          }

          //context.Response.Write("     -- Add colum " + column.Attribute.Name + "\r\n");
          //context.Response.Write("       FullName: " + column.Property.PropertyType.FullName + "\r\n");
          //if (column.Property.PropertyType.GetGenericArguments().Length != 0)
          //{
          //  context.Response.Write("       IsNullableType: " + (_s_nullable == column.Property.PropertyType.GetGenericTypeDefinition()) + "\r\n");
          //}
          //context.Response.Write("       IsValueType: " + column.Property.PropertyType.IsValueType + "\r\n");
          //context.Response.Write("       RequiredAttribute: " +

          //  (column.Property.GetCustomAttribute<RequiredAttribute>() != null) + "\r\n");

          if (!isNullable)
          {
            if(column.DefaultValue != null)
            {
              string defaultValue;
              if (column.DefaultValue.Value is string stringValue)
              {
                defaultValue = $"'{stringValue}'";
              } else if (column.DefaultValue.Value is DateTime dateValue)
              {
                defaultValue = $"''{dateValue.ToUniversalTime():S};";
              } 
              else if (column.DefaultValue.Value is int intValue)
              {
                defaultValue = intValue.ToString();
              }
              else
              {
                throw new InvalidOperationException("Unsupported default value.");
              }

            
              context.Response.Write("      [" + column.Attribute.Name + "]" + column.Attribute.TypeName + " NOT NULL DEFAULT (" + defaultValue + ")");
            }
            else
            {
              context.Response.Write("      [" + column.Attribute.Name + "]" + column.Attribute.TypeName + " NOT NULL");
            }
          }
          else
          {
            context.Response.Write("      [" + column.Attribute.Name + "]" + column.Attribute.TypeName + " NULL");
          }

          if (i + 1 < columnsAndAttributes.Length)
          {
            context.Response.Write(",\r\n");
          } 
          else
          {
            context.Response.Write("\r\n");
          }
        }

        if (keyAttribute != null)
        {
          context.Response.Write("      CONSTRAINT[PKC_dbo_" + tableName + "By_" + keyAttribute.Name + "]\r\n");
          context.Response.Write("      PRIMARY KEY CLUSTERED\r\n");
          context.Response.Write("      (\r\n");
          context.Response.Write("        [Id]\r\n");
          context.Response.Write("      )\r\n");
        }
        context.Response.Write("      WITH\r\n");
        context.Response.Write("      (\r\n");
        context.Response.Write("        IGNORE_DUP_KEY = OFF\r\n");
        context.Response.Write("      )\r\n");
        context.Response.Write("      ON[PRIMARY]\r\n");
        context.Response.Write("    );\r\n");
        context.Response.Write("    PRINT('Table `" + tableName + "` was newly created.');\r\n");
        context.Response.Write("  END\r\n");
        context.Response.Write("ELSE\r\n");
        context.Response.Write("  BEGIN\r\n");
        context.Response.Write("    PRINT('Table `" + tableName + "` was already existent.');\r\n");
        context.Response.Write("  END\r\n");
        context.Response.Write("GO\r\n\r\n");
      }


    }

    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}