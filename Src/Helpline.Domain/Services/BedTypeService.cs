using Helpline.Domain.Models.Helpers;
using Helpline.Domain.Models.Types;

namespace Helpline.Domain.Services
{
    public class BedTypeService
    {
        private readonly IDictionaryConvertable<BedType, int> _dictionaryHelper;

        public BedTypeService(IDictionaryConvertable<BedType, int> dictionaryHelper)
        {
            _dictionaryHelper = dictionaryHelper;
        }

        public IDictionary<BedType, int> GetBedDetailsFromJson(string json)
        {
            return _dictionaryHelper.ConvertToDictionary(json);
        }

        public async Task<string> SaveBedDetailsAsJson(IDictionary<BedType, int> beds)
        {
            return await _dictionaryHelper.ConvertToJsonAsync(beds);
        }
    }

}
