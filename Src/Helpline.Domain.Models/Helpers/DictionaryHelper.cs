using Helpline.Domain.Models.Types;
using Newtonsoft.Json;

namespace Helpline.Domain.Models.Helpers
{
    public class DictionaryHelper<Tkey, TValue> : IDictionaryConvertable<Tkey, TValue>
        where Tkey : Enum
    {
        public IDictionary<Tkey, TValue> ConvertToDictionary(string? jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return new Dictionary<Tkey, TValue>();
            }

            var dictionary = JsonConvert.DeserializeObject<Dictionary<Tkey, TValue>>(jsonString);

            if (dictionary is null)
            {
                return new Dictionary<Tkey, TValue>();
            }

            var result = new Dictionary<Tkey, TValue>();
            foreach (var kvp in dictionary)
            {
                if (Enum.TryParse(typeof(Tkey), kvp.Key.ToString(), true, out var key))
                {
                    result[(Tkey)key!] = kvp.Value;
                }
            }

            return result;
        }

        public async Task<string> ConvertToJsonAsync(IDictionary<Tkey, TValue> dictionary)
        {
            if (dictionary is null || dictionary.Count == 0)
            {
                return await Task.FromResult(string.Empty);
            }

            var stringKeyedDict = new Dictionary<string, TValue>();
            foreach (var kvp in dictionary)
            {
                stringKeyedDict[kvp.Key.ToString()] = kvp.Value;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(stringKeyedDict));
        }
    }

    public class BedDetail
    {
        public BedType BedType { get; set; }
        public int Quantity { get; set; }
    }
}
