using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JSONToDictionary
{
    public static class DictionaryCastExtensions
    {
        public static IDictionary<string, object> GetDictionary(this IDictionary<string, object> dictionary, string key)
        {
            return GetForType<IDictionary<string, object>>(dictionary, key);
        }

        public static T GetObject<T>(this IDictionary<string, object> dictionary, string key)
        {
            return dictionary.GetJObject(key).ToObject<T>();
        }

        public static JObject GetJObject(this IDictionary<string, object> dictionary, string key)
        {
            return (JObject)dictionary.GetDictionary(key)["JObject"];
        }

        public static IList<T> GetList<T>(this IDictionary<string, object> dictionary, string key)
        {
            return dictionary.GetForType<List<object>>(key).OfType<T>().ToList();
        }

        public static IList<T> GetListWithTypedObjects<T>(this IDictionary<string, object> dictionary, string key)
        {
            return dictionary.GetListWithObjects(key)
                .Select(d => ((JObject) d["JObject"]).ToObject<T>())
                .ToList();
        }

        public static IList<IDictionary<string,object>> GetListWithObjects(this IDictionary<string, object> dictionary, string key)
        {
            return dictionary
                .GetForType<List<object>>(key)
                .OfType<IDictionary<string, object>>().ToList();
        }

        public static T GetForType<T>(this IDictionary<string, object> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var obj))
            {
                if (obj is T variable)
                {
                    return variable;
                }
            }

            return default(T);
        }
    }
}