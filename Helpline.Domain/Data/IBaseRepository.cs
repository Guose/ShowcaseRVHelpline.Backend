namespace Helpline.Domain.Data
{
    public interface IBaseRepository<T, TKey>
    {
        Task<IEnumerable<T>> GetAllEntitiesAsync();
        Task<T> GetEntityByIdAsync(TKey id);
        Task<bool> CreateEntityAsync(T model);
        Task<bool> DeleteEntityAsync(T model);
        Task<bool> UpdateEntityAsync(T model);
        bool HasChanges();
    }
}
