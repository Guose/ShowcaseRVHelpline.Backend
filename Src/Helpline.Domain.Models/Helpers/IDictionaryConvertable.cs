namespace Helpline.Domain.Models.Helpers
{
    public interface IDictionaryConvertable<TKey, TValue> where TKey : Enum
    {
        IDictionary<TKey, TValue> ConvertToDictionary(string jsonString);
        Task<string> ConvertToJsonAsync(IDictionary<TKey, TValue> dictionary);
    }
}
