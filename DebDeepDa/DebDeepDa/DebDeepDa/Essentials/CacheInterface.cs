using System;
using System.Collections.Generic;
using System.Text;

namespace DebDeepDa.Essentials
{
    interface CacheInterface
    {
        void add(string key, Object o);
        Object get(string key);
        void clear();
    }
}
