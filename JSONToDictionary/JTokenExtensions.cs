using Newtonsoft.Json.Linq;

namespace JSONToDictionary
{
    public static class JTokenExtensions {
        public static string GetName(this JToken token)
        {
            if(token is JProperty jProperty)
            {
                return jProperty.Name;
            }
            return string.Empty;
        }

        public static object GetValue(this JToken token)
        {
            if (token.First is JValue jProperty)
            {
                return jProperty.Value;
            }
            return null;
        }
    }
}