using Newtonsoft.Json;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Extensions
    {
        public static T GetKeyByValue<T, W>(this Dictionary<T, W> dict, W val)
        {
            T key = default;
            foreach (KeyValuePair<T, W> pair in dict)
            {
                if (EqualityComparer<W>.Default.Equals(pair.Value, val))
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }

        public static T FromJson<T>(this string yes) =>
            Newtonsoft.Json.JsonConvert.DeserializeObject<T>(yes, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });

        public static string ToJson<T>(this T obj) =>
            Newtonsoft.Json.JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
    }
}
