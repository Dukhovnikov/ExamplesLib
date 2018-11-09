using Newtonsoft.Json;

namespace CommonData.ClassLib.Utils
{
    public static class JsonUtils
    {
        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj, Formatting.Indented);

        public static T FromJson<T>(this string s) where T : class
        {
            if (!string.IsNullOrEmpty(s))
            {
                return JsonConvert.DeserializeObject<T>(s);
            }

            return null;
        }

        /// <summary>Если не может распарсить Json - возвращает значение указанное в defaultValue</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s">Json строка</param>
        /// <param name="defaultValue">Значение, возвращаемое в случае если нет возможности распарсить json</param>
        /// <returns>Результирующий распарсенный объект</returns>
        public static T FromJson<T>(this string s, T defaultValue) where T : class
        {
            try
            {
                return FromJson<T>(s);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}