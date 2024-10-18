using Helpline.Domain.Commands;

namespace Helpline.ServiceCaseService.Commands
{
    public class CreateServiceCaseCommand : CommandBase
    {
        public override Task<bool> CanExecuteAsync(object parameter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task ExecuteAsync(object parameter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
