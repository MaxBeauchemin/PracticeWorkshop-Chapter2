using Domain.Types;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;

namespace Domain.Services.Common
{
    public static class LoggerService
    {
        public static void Log(LogArea logArea, LogType logType, string message, object data)
        {
            var connectionString = AppSettings.GetConnectionString("DatabaseContext");

            var conn = new SqlConnection(connectionString);

            try
            {
                string messageStr = GeneralHelper.LimitLength(message, 250);

                if (messageStr == null) throw new ArgumentException("Message cannot be null");

                string dataStr = string.Empty;

                if (data != null)
                {
                    try
                    {
                        dataStr = JsonConvert.SerializeObject(data);
                    }
                    catch { }
                }

                var sqlInsert = @"INSERT INTO [dbo].[Logs] ([LogArea], [LogType], [Message], [Data], [Timestamp]) VALUES (@LogArea, @LogType, @Message, @Data, GETDATE())";

                using (var command = new SqlCommand(sqlInsert, conn))
                {
                    conn.Open();

                    command.Parameters.Add(new SqlParameter("@LogArea", logArea.ToString()));
                    command.Parameters.Add(new SqlParameter("@LogType", logType.ToString()));
                    command.Parameters.Add(new SqlParameter("@Message", messageStr));
                    command.Parameters.Add(new SqlParameter("@Data", dataStr));

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
