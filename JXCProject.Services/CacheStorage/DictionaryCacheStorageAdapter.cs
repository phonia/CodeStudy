using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.Services.CacheStorage
{
    public class DictionaryCacheStorageAdapter : ICacheStorage
    {
        private static IDictionary<string, object> dic = new Dictionary<string, object>();

        public void Add(string key, object value)
        {
            dic.Add(key, value);
        }

        public void Remove(string key)
        {
            dic.Remove(key);
        }

        public T Retrieve<T>(string key)
        {
            T value = (T)dic[key];
            if (value == null)
                return default(T);
            return value;
        }
    }
}
