using System;
using System.Data;
using Application.Core;
using Application.DomainModel;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Application.SqlProviders
{
    public sealed class SqlPerformanceCounterProvider : DbConnection
    {
        private MySqlTransaction _tr;

        /// <summary>
        /// Retrieves all Performance Counter Items
        /// </summary>
        /// <returns></returns>
        public List<PerformanceCounter> GetAllPerformanceCounterItems(int lastPerformanceCounterId)
        {
            using (var con = new MySqlConnection(ConnString))
            {
                var cmd = new MySqlCommand(Sql.GetAllPerformanceCounterItems(), con) { CommandType = CommandType.Text };
                cmd.Parameters.Add("@LastCacheDictionaryPerformanceCounterId", MySqlDbType.Int32).Value = lastPerformanceCounterId;
                con.Open();

                try
                {
                    _tr = con.BeginTransaction();
                    return GetPerformanceCounterItemsCollectionFromReader(ExecuteReader(cmd));
                    _tr.Commit();
                }
                catch (Exception ex)
                {
                    _tr.Rollback();
                    return null;
                }
            }
        }

        private static PerformanceCounter GetPerformanceCounterItemsFromReader(IDataRecord reader)
        {
            return new PerformanceCounter(
                Convert.ToInt32(reader[0]),
                reader[1].ToString(),
                (Convert.ToInt32(reader[2]) == 1),
                reader[3].ToString(),
                reader[4].ToString(),
                reader[5].ToString()
            );
        }

        private static List<PerformanceCounter> GetPerformanceCounterItemsCollectionFromReader(IDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            var monitorItems = new List<PerformanceCounter>();

            while (reader.Read())
                monitorItems.Add(GetPerformanceCounterItemsFromReader(reader));

            return monitorItems;
        }
    }
}
