using System;
using System.Collections.Generic;
using System.Linq;
using Application.DomainModel;
using Application.SqlProviders;

namespace Web.Helpers
{
    public static class MonitorDictionaryCreatorHelpers
    {
        public static DateTime LastDate { get; private set; }

        public static Dictionary<int, List<Monitor>> AddItemsFromDatabaseToMonitorCacheObject(Dictionary<int, List<Monitor>> existingDictionary, DateTime lastInsertedTimeStamp)
        {
            var newItemsList = new SqlMonitorProvider().GetAllMonitorItems(lastInsertedTimeStamp);

            var currentDictionary = existingDictionary ?? new Dictionary<int, List<Monitor>>();

            if (newItemsList != null)
            {
                if (newItemsList.Count > 0)
                {
                    foreach (var item in newItemsList)
                    {
                        List<Monitor> retrievedValueListForExistingKey;

                        if (currentDictionary.TryGetValue(item.PerformanceCounterId, out retrievedValueListForExistingKey))
                        {
                            if (retrievedValueListForExistingKey != null && !retrievedValueListForExistingKey.Contains(item))
                            {
                                retrievedValueListForExistingKey.Add(item);
                                currentDictionary[item.PerformanceCounterId] = retrievedValueListForExistingKey;
                            }
                        }
                        else
                            currentDictionary.Add(item.PerformanceCounterId, new List<Monitor> { item });
                    }

                    LastDate = newItemsList.Max(x => x.From);
                }
            }

            return currentDictionary;
        }
    }
}