using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JSONToDictionary
{
    public static class JSONToDictionary
    {
        public static IDictionary<string, object> ToDictionary(string json)
        {
            var jObject =  JObject.Parse(json);
            return ToDictionary(jObject);
        }

        public static IDictionary<string, object> ToDictionary(JObject obj)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary["JObject"] = obj;
            var enumerable = obj.Children().ToList();

            foreach (var child in enumerable)
            {
                if (child.First is JArray jArray)
                {
                    dictionary[child.GetName()] = ToList(jArray);
                }
                if (child.First is JValue)
                {
                    dictionary[child.GetName()] = child.GetValue();
                }
                else if (child.First is JObject jObject)
                {
                    dictionary[child.GetName()] = ToDictionary(jObject);
                }
            }
            return dictionary;
        }

        private static object ToList(JArray jArray)
        {
            return jArray.Children()
                .Select(GetArrayItemValue)
                .ToList();
           
        }

        private static object GetArrayItemValue(JToken jToken)
        {
            if (jToken is JValue jValue)
            {
                return jValue.Value;
            }

            if (jToken is JArray jArray)
            {
                return ToList(jArray);
            }

            if (jToken is JObject jObject)
            {
                return ToDictionary(jObject);
            }

            return null;
        }
    }
}
