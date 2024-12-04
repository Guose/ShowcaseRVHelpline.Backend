using Helpline.Common.Interfaces;
using Helpline.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Data
{
    public abstract class BaseRepository<TEntity, TContext, TKey>(TContext context, ILogging logging) : IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext Context { get; } = context;
        protected ILogging Logging { get; } = logging;

        public virtual async Task<bool> CreateEntityAsync(TEntity model, CancellationToken cancellationToken = default)
        {
            try
            {
                if (model == null)
                    return false;

                await Context.Set<TEntity>().AddAsync(model, cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(CreateEntityAsync)}:{typeof(TEntity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<bool> UpdateEntityAsync(TEntity model, CancellationToken cancellationToken = default)
        {
            try
            {
                if (model is null)
                    return false;

                await Task.Run(() => Context.Set<TEntity>().Update(model), cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(UpdateEntityAsync)}:{typeof(TEntity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<bool> DeleteEntityAsync(TEntity model, CancellationToken cancellationToken = default)
        {
            try
            {
                if (model == null)
                    return false;

                await Task.Run(() => Context.Set<TEntity>().Remove(model), cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(DeleteEntityAsync)}:{typeof(TEntity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await Context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(GetAllEntitiesAsync)}:{typeof(TEntity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public virtual async Task<TEntity> GetEntityByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            try
            {
                var results = await Context.Set<TEntity>().FindAsync(id, cancellationToken);
                return results!;
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(GetAllEntitiesAsync)}:{typeof(TEntity).Name} Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public bool HasChanges()
        {
            return Context.ChangeTracker.HasChanges();
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await Context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Logging.LogError(ex, $"{nameof(SaveAsync)}: Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
