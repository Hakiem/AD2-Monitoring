namespace Application.SqlStatements
{
    public partial class SqlStatements
    {
        private const string TableName1 = "`Monitor`";

        public string GetAllMonitorItems()
        {
            // Fetch 500,000 rows at a time
            return string.Format(
                @"SELECT performanceCounterId, server, M.count, M.min, M.max, M.avg, M.from" + 
                 "  FROM {0} M WHERE M.from > @LastCacheDictionaryTimeStamp LIMIT 50000", TableName1);
        }
    }
}
