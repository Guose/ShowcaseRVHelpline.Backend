using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.Common.Helpers
{
    public static class NewtonSoftJsonHelper
    {
        private static readonly JsonSerializerSettings settings = new()
        {
            Formatting = Formatting.Indented,
            Converters = { new StringEnumConverter() }
        };

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings)!;
        }
    }
}
