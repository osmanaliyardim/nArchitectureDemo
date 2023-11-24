namespace Core.CrossCuttingConcerns.SeriLog.ConfigurationModels;

public class SqlServerConfiguration
{
    public string ConnectionString { get; set; }

    public string TableName { get; set; }

    public bool AutoCreateSqlTable { get; set; }

    public SqlServerConfiguration()
    {
        ConnectionString = string.Empty;
        TableName = string.Empty;
    }

    public SqlServerConfiguration(string connectionString, string tableName, bool autoCreateSqlTable)
    {
        ConnectionString = connectionString;
        TableName = tableName;
        AutoCreateSqlTable = autoCreateSqlTable;
    }
}