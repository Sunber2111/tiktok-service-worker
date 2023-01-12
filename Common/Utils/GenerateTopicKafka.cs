namespace Common.Utils
{
    public static class GenerateTopicKafka
    {
        public static string GenerateTopic(
            this string tableName,
            string databaseName = "Tiktok",
            string serverName = "sqlserver",
            string schemaName = "dbo")
        {
            return $"{serverName}.{databaseName}.{schemaName}.{tableName}";
        }

    }
}

