using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXCProject.BLL.CacheStorage
{
    public interface ICacheStorage
    {
        void Add(string key, Object value);
        void Remove(string key);
        T Retrieve<T>(string key);
    }
}
