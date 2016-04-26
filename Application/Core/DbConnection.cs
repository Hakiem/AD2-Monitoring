using System.Data;
using System.Data.Common;

namespace Application.Core
{
    public class DbConnection : ConfigurationSection
    {
        protected readonly SqlStatements.SqlStatements Sql;

        protected DbConnection()
        {
            Sql = new SqlStatements.SqlStatements();
        }

        protected static IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior = CommandBehavior.Default)
        {
            return cmd.ExecuteReader(behavior);
        }
    }
}
