namespace Helpline.Common.Interfaces.Commands
{
    public interface ICreateCommand<T>
    {
        Task<bool> ExecuteCreateAsync(T entity);
    }
}
