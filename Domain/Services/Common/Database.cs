using Domain.Attributes;
using Domain.DTOs.Common;
using Domain.Resources;
using Domain.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace Domain.Services.Common
{
    public class Database
    {
        public static Response<List<T>> Read<T>(string query)
        {
            var response = new Response<List<T>>();
            var cMethodName = "Database.Read<T>(..)";

            var connectionString = AppSettings.GetConnectionString("Entities");

            var conn = new SqlConnection(connectionString);

            try
            {
                using (var command = new SqlCommand(query, conn))
                {
                    conn.Open();

                    var reader = command.ExecuteReader();

                    var properties = typeof(T).GetProperties();

                    var propNames = new List<string>();

                    foreach (var prop in properties)
                    {
                        var ignoreSql = prop.GetCustomAttribute(typeof(SqlIgnore)) as SqlIgnore;

                        if (ignoreSql == null)
                        {
                            propNames.Add(prop.Name);
                        }
                    }

                    var output = new List<T>();

                    while (reader.Read())
                    {
                        var item = new Dictionary<string, object>();

                        foreach (var prop in propNames)
                        {
                            item.Add(prop, reader[prop]);
                        }

                        var itemObj = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(item));

                        output.Add(itemObj);
                    }

                    response.Value = output;

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                var logData = new
                {
                    Query = query,
                    Exception = ex
                };

                var msg = string.Format(DomainResource.ErrorOccuredInXY, cMethodName, ex.Message);

                LoggerService.Log(LogArea.Database, GeneralHelper.ExceptionLogType(ex), msg, logData);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return response;
        }
    }
}
