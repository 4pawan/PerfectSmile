using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfectSmile.ViewModels;

namespace PerfectSmile.Helper
{
    internal class StorageManager
    {
        private static IDictionary<string, object> _dictionary = new Dictionary<string, object>();
        public static void Add(string key, object val)
        {
            _dictionary.Add(key, val);
        }
        public static T Get<T>(string key)
        {
            return (T)_dictionary[key];
        }
        public static bool TryGet<T>(string key, out T value)
        {
            object result;
            if (_dictionary.TryGetValue(key, out result) && result is T)
            {
                value = (T)result;
                return true;
            }
            value = default(T);
            return false;
        }

    }
}
