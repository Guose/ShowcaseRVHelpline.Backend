namespace Helpline.Common.Interfaces.Commands
{
    public interface IUpdateCommand<T>
    {
        Task<bool> ExecuteUpdateAsync(T entity);
    }
}
