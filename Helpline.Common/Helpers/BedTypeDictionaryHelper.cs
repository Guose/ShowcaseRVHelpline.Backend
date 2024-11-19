using Helpline.Common.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Helpline.Common.Helpers
{
    public class BedTypeDictionaryHelper : IBedTypeConvertable
    {
        public IDictionary<BedType, int> ConvertToDictionaryAsync(string bedDetails)
        {
            try
            {
                var bedDetailsList = JsonConvert.DeserializeObject<List<BedDetail>>(bedDetails, new JsonSerializerSettings()
                {
                    Converters = new List<JsonConverter> { new StringEnumConverter() }
                }) ?? [];

                return bedDetailsList.ToDictionary(b => b.BedType, b => b.Quantity);
            }
            catch (JsonException)
            {
                return new Dictionary<BedType, int>();
            }
        }

        public async Task<string> ConvertToJsonAsync(IDictionary<BedType, int> beds)
        {
            var bedDetailsList = beds.Select(b => new BedDetail
            {
                BedType = b.Key,
                Quantity = b.Value
            })
            .ToList();

            return await Task.FromResult(JsonConvert.SerializeObject(bedDetailsList, new JsonSerializerSettings()
            {
                Converters = [new StringEnumConverter()]
            }));
        }
    }

    public class BedDetail
    {
        public BedType BedType { get; set; }
        public int Quantity { get; set; }
    }
}
