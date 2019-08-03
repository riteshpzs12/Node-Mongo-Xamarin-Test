using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebDeepDa.Essentials
{
    class Cache : CacheInterface
    {
        public Cache()
        {
            Barrel.ApplicationId = "com.ritesh.medicaltest1";
        }

        public void add(string key, object o)
        {
            Barrel.Current.Add<Object>(key, o, new TimeSpan(0,2,0));
        }

        public void clear()
        {
            Barrel.Current.EmptyAll();
        }

        public Object get(string key)
        {
            return Barrel.Current.Get<Object>(key);
        }
    }
}
