namespace Helpline.Domain.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllEntitiesAsync();
        Task<bool> CreateEntityAsync(T model);
        Task SaveAsync();
        bool HasChanges();
        Task<bool> DeleteEntityAsync(T model);
    }
}
