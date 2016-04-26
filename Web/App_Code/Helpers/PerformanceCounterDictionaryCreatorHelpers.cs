using System.Collections.Generic;
using System.Linq;
using Application.SqlProviders;
using Web.Models;

namespace Web.Helpers
{
    public static class PerformanceCounterDictionaryCreatorHelpers
    {
        public static int LastPerformanceCounterId { get; private set; }

        public static SortedDictionary<string, List<TreeViewPropertiesClass>> AddItemsFromDatabaseToPerformanceCounterCacheObject(
            SortedDictionary<string, List<TreeViewPropertiesClass>> existingDictionary, 
            int lastCachedPerformanceCounterId)
        {
            var newItemsList = new SqlPerformanceCounterProvider().GetAllPerformanceCounterItems(lastCachedPerformanceCounterId);

            var currentDictionary = existingDictionary ?? new SortedDictionary<string, List<TreeViewPropertiesClass>>();

            if (newItemsList != null && newItemsList.Count > 0)
            {
                foreach (var item in newItemsList)
                {
                    var splitName = item.Name.Split('.');
                    List<TreeViewPropertiesClass> returnedSubNameAndItsIdCollection;

                    if(currentDictionary.TryGetValue(splitName[0], out returnedSubNameAndItsIdCollection))
                    {
                        var temporaryTreeViewPropertiesClass = new TreeViewPropertiesClass
                            {
                                SubItemId = item.PerformanceCounterId,
                                SubItemName = item.Name.Replace(splitName[0] + ".", "")
                            };

                        if (!returnedSubNameAndItsIdCollection.Contains(temporaryTreeViewPropertiesClass))
                        {
                            returnedSubNameAndItsIdCollection.Add(temporaryTreeViewPropertiesClass);
                            currentDictionary[splitName[0]] = returnedSubNameAndItsIdCollection;
                        }
                    }
                    else
                    {
                        currentDictionary.Add(
                            splitName[0],
                            new List<TreeViewPropertiesClass>
                                {
                                    new TreeViewPropertiesClass
                                        {
                                            SubItemId = item.PerformanceCounterId,
                                            SubItemName = item.Name.Replace(splitName[0] + ".", "")
                                        }
                                });
                    }
                }

                LastPerformanceCounterId = newItemsList.Max(x => x.PerformanceCounterId);
            }
            return currentDictionary;
        }
    }
}