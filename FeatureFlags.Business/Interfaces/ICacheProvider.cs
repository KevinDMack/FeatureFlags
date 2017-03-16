using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.Interfaces
{
    public interface ICacheProvider
    {
        T GetFromCache<T>(string key);
        void AddToCache(string key, object value);
        bool KeyExists(string key);
    }
}
