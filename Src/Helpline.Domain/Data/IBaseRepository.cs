using Helpline.Domain.Shared;

namespace Helpline.Domain.Data
{
    public interface IBaseRepository<T, TKey>
    {
        Task<IEnumerable<T>> GetAllEntitiesAsync(CancellationToken cancellationToken);
        Task<T> GetEntityByIdAsync(TKey id, CancellationToken cancellationToken);
        Task<Result> CreateEntityAsync(T model, CancellationToken cancellationToken);
        Task<Result> DeleteEntityAsync(T model, CancellationToken cancellationToken);
        Task<Result> UpdateEntityAsync(T model, CancellationToken cancellationToken);
        bool HasChanges();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
