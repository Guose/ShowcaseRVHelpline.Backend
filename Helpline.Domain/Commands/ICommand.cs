namespace Helpline.Domain.Commands
{
    public interface ICommand
    {
        Task<bool> CanExecuteAsync(object parameter);
        Task ExecuteAsync(object parameter);
    }
}
