using Helpline.DataAccess.Models.Types;

namespace Helpline.DataAccess.Models.Helpers
{
    public interface IBedTypeConvertable
    {
        IDictionary<BedType, int> ConvertToDictionaryAsync(string bedDetails);
        Task<string> ConvertToJsonAsync(IDictionary<BedType, int> beds);
    }
}
