namespace Application.SqlStatements
{
    public partial class SqlStatements
    {
        private const string TableName2 = "`performanceCounter`";

        public string GetAllPerformanceCounterItems()
        {
            return string.Format("SELECT * FROM {0} WHERE performanceCounterId > @LastCacheDictionaryPerformanceCounterId", TableName2);
        }
    }
}
