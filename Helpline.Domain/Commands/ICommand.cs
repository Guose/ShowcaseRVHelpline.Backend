namespace Helpline.Domain.Commands
{
    public interface ICommand
    {
        Task<bool> CanExecuteAsync(object parameter, CancellationToken cancellationToken);
        Task ExecuteAsync(object parameter, CancellationToken cancellationToken);
    }
}
