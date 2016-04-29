using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JXCProject.Services.CacheStorage
{
    public class HttpContextCacheAdapter : ICacheStorage
    {
        public void Add(string key, object value)
        {
            HttpContext.Current.Cache.Insert(key, value);
        }

        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public T Retrieve<T>(string key)
        {
            T value = (T)HttpContext.Current.Cache.Get(key);
            if (value == null)
                return default(T);
            return value;
        }
    }
}
