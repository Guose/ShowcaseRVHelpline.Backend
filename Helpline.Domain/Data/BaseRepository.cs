using Helpline.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Domain.Data
{
    public abstract class BaseRepository<TEnity, TContext, TKey>(TContext context, ILogging logging) : IBaseRepository<TEnity, TKey>
        where TEnity : class
        where TContext : DbContext
    {
        protected TContext Context { get; } = context;
        protected ILogging Logging { get; } = logging;

        public virtual async Task<bool> CreateEntityAsync(TEnity model)
        {
            try
            {
                if (model == null)
                    return false;

                await Context.Set<TEnity>().AddAsync(model);

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(CreateEntityAsync)}:{typeof(TEnity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<bool> UpdateEntityAsync(TEnity model)
        {
            try
            {
                if (model == null)
                    return false;

                await Task.Run(() => Context.Set<TEnity>().Update(model));

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(UpdateEntityAsync)}:{typeof(TEnity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<bool> DeleteEntityAsync(TEnity model)
        {
            try
            {
                if (model == null)
                    return false;

                await Task.Run(() => Context.Set<TEnity>().Remove(model));

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(DeleteEntityAsync)}:{typeof(TEnity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<IEnumerable<TEnity>> GetAllEntitiesAsync()
        {
            try
            {
                return await Context.Set<TEnity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(GetAllEntitiesAsync)}:{typeof(TEnity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<TEnity> GetEntityByIdAsync(TKey id)
        {
            try
            {
                var results = await Context.Set<TEnity>().FindAsync(id);
                return results!;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(GetAllEntitiesAsync)}:{typeof(TEnity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public bool HasChanges()
        {
            return Context.ChangeTracker.HasChanges();
        }

        public async Task<int> SaveAsync()
        {            
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(SaveAsync)}: Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
