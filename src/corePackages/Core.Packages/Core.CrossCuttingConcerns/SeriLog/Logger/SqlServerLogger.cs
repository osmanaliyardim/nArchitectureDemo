using Microsoft.Extensions.Configuration;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using Core.CrossCuttingConcerns.SeriLog.ConfigurationModels;
using Core.CrossCuttingConcerns.SeriLog.Messages;

namespace Core.CrossCuttingConcerns.SeriLog.Logger;

public class SqlServerLogger : LoggerServiceBase
{
    public SqlServerLogger(IConfiguration configuration)
    {
        var logConfiguration =
            configuration.GetSection("SerilogConfigurations:SqlServerConfiguration").Get<SqlServerConfiguration>()
            ?? throw new Exception(SeriLogMessages.NullOptionsMessage);

        var sinkOptions = new MSSqlServerSinkOptions()
        {
            TableName = logConfiguration.TableName,
            AutoCreateSqlDatabase = logConfiguration.AutoCreateSqlTable
        };

        var columnOptions = new ColumnOptions();

        var seriLogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(logConfiguration.ConnectionString, sinkOptions, columnOptions: columnOptions)
            .CreateLogger();

        Logger = seriLogConfig;
    }
}