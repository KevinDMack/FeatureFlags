using FeatureFlags.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Web.Providers
{
    public class ServerCacheProvider : ICacheProvider
    {
        public bool KeyExists(string key)
        {
            var record = System.Web.HttpContext.Current.Cache.Get(key);
            if (record == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public T GetFromCache<T>(string key)
        {
            var record = System.Web.HttpContext.Current.Cache.Get(key);
            if (record == null)
            {
                return default(T);
            }

            return (T)record;
        }

        public void AddToCache(string key, object value)
        {
            System.Web.HttpContext.Current.Cache.Insert(key, value);
        }
    }
}
