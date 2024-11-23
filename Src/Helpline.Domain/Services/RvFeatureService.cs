using Helpline.Domain.Models.Helpers;
using Helpline.Domain.Models.Types;

namespace Helpline.Domain.Services
{
    public class RvFeatureService
    {
        private readonly IDictionaryConvertable<VehicleFeaturesType, bool> _dictionaryHelper;

        public RvFeatureService(IDictionaryConvertable<VehicleFeaturesType, bool> dictionaryHelper)
        {
            _dictionaryHelper = dictionaryHelper;
        }

        public IDictionary<VehicleFeaturesType, bool> GetFeaturesFromJson(string json)
        {
            return _dictionaryHelper.ConvertToDictionary(json);
        }

        public async Task<string> SaveFeaturesAsJson(IDictionary<VehicleFeaturesType, bool> features)
        {
            return await _dictionaryHelper.ConvertToJsonAsync(features);
        }
    }

}
