using Helpline.Domain.Commands;

namespace Helpline.ServiceCallHub.Commands
{
    public abstract class CommandBase : ICommand
    {
        public abstract Task<bool> CanExecuteAsync(object parameter, CancellationToken cancellationToken);

        public abstract Task ExecuteAsync(object parameter, CancellationToken cancellationToken);

        protected void LogCommandExecution(string commandName)
        {
            // Logging that applies to all commands
            Console.WriteLine($"{commandName} is executing at {DateTime.Now}");
        }

        protected async Task<bool> ValidateParameters(object parameter)
        {
            // Shared validation logic if needed
            if (parameter == null)
            {
                Console.WriteLine("Validation failed: Parameter cannot be null.");
                return false;
            }

            return await Task.FromResult(true);
        }
    }
}
