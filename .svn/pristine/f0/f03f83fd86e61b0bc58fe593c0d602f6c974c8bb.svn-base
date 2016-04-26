using System;
using System.Web;

namespace Web.Helpers
{
    public class CacheHelper
    {
        public static void Add<T>(T o, string key)
        {
            HttpRuntime.Cache.Insert(
                key,
                o,
                null,
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                TimeSpan.FromMinutes(40000)
            );
        }

        public static void Clear(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public static bool Exists(string key)
        {
            return HttpRuntime.Cache[key] != null;
        }

        public static bool Get<T>(string key, out T value)
        {

            //var value = HttpContext.Current.Cache[key];
            //if (value == null)
            //{
            //    HttpContext.Current.Cache[key] = new T();
            //    return false;
            //}
            //return true;

            try
            {
                if (!Exists(key))
                {
                    value = default(T);
                    return false;
                }

                value = (T)HttpContext.Current.Cache[key];
            }
            catch
            {
                value = default(T);
                return false;
            }

            return true;
        }

        public static T GetCachedItem<T>(string key) where T : class
        {
            return (T)HttpRuntime.Cache[key];
        }
    }
}