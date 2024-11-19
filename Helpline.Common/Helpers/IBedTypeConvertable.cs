using Helpline.Common.Types;

namespace Helpline.Common.Helpers
{
    public interface IBedTypeConvertable
    {
        IDictionary<BedType, int> ConvertToDictionaryAsync(string bedDetails);
        Task<string> ConvertToJsonAsync(IDictionary<BedType, int> beds);
    }
}
