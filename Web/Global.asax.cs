using System;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.App_Start;

namespace Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Clear the cache for any traces of the cached elements
            // this ensures a clear start up with no components connected in the cache section of the computer memory
            Helpers.CacheHelper.Clear("LastInsertedTimeStamp");
            Helpers.CacheHelper.Clear("lastCachedPerformanceCounterId");
            Helpers.CacheHelper.Clear("CachedMonitorDictionary");
            Helpers.CacheHelper.Clear("CachedPerformancCounterDictionary");

            // Add default cache starting objects
            Helpers.CacheHelper.Add(Convert.ToDateTime("2000-01-01"), "LastInsertedTimeStamp");
            Helpers.CacheHelper.Add(0, "lastCachedPerformanceCounterId");

            // Fetch the data to fill dictionaries in the cache
            Helpers.CacheToDictionaryToCacheHelpers.FillObjectsToCacheForMonitorTable();
            Helpers.CacheToDictionaryToCacheHelpers.FillObjectsToCacheForPerformanceCounterTable();

            // initiate a thread to synchroneously fetch the remaining data in the database
            var tsTask = new Thread(TaskLoop) {IsBackground = true, Priority = ThreadPriority.Normal, Name = "DatabaseToCacheThread"};
            tsTask.Start();
        }

        private static void TaskLoop()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromMinutes(2));
                Helpers.CacheToDictionaryToCacheHelpers.FillObjectsToCacheForMonitorTable();
                Helpers.CacheToDictionaryToCacheHelpers.FillObjectsToCacheForPerformanceCounterTable();
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}