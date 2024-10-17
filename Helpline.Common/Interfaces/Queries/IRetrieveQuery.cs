namespace Helpline.Common.Interfaces.Queries
{
    public interface IRetrieveQuery<T, TKey>
    {
        Task<IEnumerable<T>> ExecuteGetAllAsync();
        Task<T> ExecuteGetByIdAsync(TKey id);
    }
}
