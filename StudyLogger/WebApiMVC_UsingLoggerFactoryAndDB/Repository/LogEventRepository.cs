using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using WebApiMVC_UsingLoggerFactoryAndDB.Models;
using WebApiMVC_UsingLoggerFactoryAndDB.Models.Enum;

namespace WebApiMVC_UsingLoggerFactoryAndDB.Repository
{
    public class LogEventRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILogger _logger;

        public LogEventRepository(IDbConnection connection, ILogger<LogEventRepository> logger )
        {
            _connection = connection;
            _logger = logger;
        }

        public void Log(LogLevel logLevel, LogType logType, string message, params object[] args)
        {
            logLevel = LogLevel.None == logLevel ? LogLevel.Information : logLevel;

            LogDb(logType, logLevel, string.Format(message, args)).Wait();
            _logger.Log(logLevel, (int)logType, message, args);
        }

        public async Task<IEnumerable<LogEventModel>> GetAllLogs()
        {
            Log(LogLevel.Information, LogType.GetAllLogEvents, "Listar todos os logs!");

            string sql = @"SELECT * FROM logger.log_event ORDER BY ""CreatedTime"" DESC";
            return await _connection.QueryAsync<LogEventModel>(sql);
        }

        private async Task LogDb(LogType logType, LogLevel logLevel, string message)
        {
            string sql = @"INSERT INTO logger.log_event 
                            (""Id"", ""EventId"", ""LogLevel"", ""Message"", ""CreatedTime"") 
                            VALUES (@Id, @LogType, @LogLevel, @Message, @Date)";
            await _connection.QuerySingleOrDefaultAsync(sql, new
            {
                Id = Guid.NewGuid(),
                LogType = (int)logType,
                LogLevel = logLevel.ToString(),
                Message = message,
                Date = DateTime.UtcNow
            });
        }
    }
}
