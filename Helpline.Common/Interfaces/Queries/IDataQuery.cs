namespace Helpline.Common.Interfaces.Queries
{
    public interface IDataQuery<T, TKey>
    {
        Task<IEnumerable<T>> ExecuteGetAllAsync();
        Task<T> ExecuteGetByIdAsync(TKey id);
    }
}
