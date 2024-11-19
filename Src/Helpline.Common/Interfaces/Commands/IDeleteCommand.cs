namespace Helpline.Common.Interfaces.Commands
{
    public interface IDeleteCommand<T>
    {
        Task<bool> ExecuteDeleteAsync(T entity);
    }
}
