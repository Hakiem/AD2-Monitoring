using System;
using System.Collections.Generic;
using System.Web;
using Application.DomainModel;
using Web.Models;

namespace Web.Helpers
{
    public static class CacheToDictionaryToCacheHelpers
    {
        public static void FillObjectsToCacheForMonitorTable()
        {
            if (!CacheHelper.Exists("LastInsertedTimeStamp")) return;

            var lastTimestampFromCache = Convert.ToDateTime(HttpRuntime.Cache.Get("LastInsertedTimeStamp"));

            if (!CacheHelper.Exists("CachedMonitorDictionary"))
            {
                CacheHelper.Add(
                    MonitorDictionaryCreatorHelpers.AddItemsFromDatabaseToMonitorCacheObject(null, lastTimestampFromCache), "CachedMonitorDictionary");
            }
            else
            {
                var retrievedMonitorDictionaryFromCache = HttpRuntime.Cache.Get("CachedMonitorDictionary") as Dictionary<int, List<Monitor>>;

                CacheHelper.Add(
                    MonitorDictionaryCreatorHelpers.AddItemsFromDatabaseToMonitorCacheObject(retrievedMonitorDictionaryFromCache, lastTimestampFromCache),
                    "CachedMonitorDictionary"
                    );
            }

            CacheHelper.Add(MonitorDictionaryCreatorHelpers.LastDate, "LastInsertedTimeStamp");
        }

        public static void FillObjectsToCacheForPerformanceCounterTable()
        {
            if (!CacheHelper.Exists("lastCachedPerformanceCounterId")) return;

            var lastPerformanceCounterIdFromCache = Convert.ToInt32(HttpRuntime.Cache.Get("lastCachedPerformanceCounterId"));

            if (!CacheHelper.Exists("CachedPerformancCounterDictionary"))
            {
                CacheHelper.Add(
                    PerformanceCounterDictionaryCreatorHelpers.AddItemsFromDatabaseToPerformanceCounterCacheObject(null, lastPerformanceCounterIdFromCache),
                    "CachedPerformancCounterDictionary"
                    );
            }
            else
            {
                var retrievedPerformanceCounterDictionaryFromCache = HttpRuntime.Cache.Get("CachedPerformancCounterDictionary") as SortedDictionary<string, List<TreeViewPropertiesClass>>;

                CacheHelper.Add(
                    PerformanceCounterDictionaryCreatorHelpers.AddItemsFromDatabaseToPerformanceCounterCacheObject(retrievedPerformanceCounterDictionaryFromCache, lastPerformanceCounterIdFromCache),
                    "CachedPerformancCounterDictionary"
                    );
            }

            CacheHelper.Add(PerformanceCounterDictionaryCreatorHelpers.LastPerformanceCounterId, "lastCachedPerformanceCounterId");
        }
    }
}