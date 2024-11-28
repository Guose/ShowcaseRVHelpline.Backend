namespace Helpline.Domain.Data
{
    public interface IBaseRepository<T, TKey>
    {
        Task<IEnumerable<T>> GetAllEntitiesAsync(CancellationToken cancellationToken);
        Task<T> GetEntityByIdAsync(TKey id, CancellationToken cancellationToken);
        Task<bool> CreateEntityAsync(T model, CancellationToken cancellationToken);
        Task<bool> DeleteEntityAsync(T model, CancellationToken cancellationToken);
        Task<bool> UpdateEntityAsync(T model, CancellationToken cancellationToken);
        bool HasChanges();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
