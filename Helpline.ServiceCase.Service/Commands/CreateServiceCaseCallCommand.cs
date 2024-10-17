using Helpline.Domain.Commands;

namespace Helpline.ServiceCaseService.Commands
{
    public class CreateServiceCaseCallCommand : CommandBase
    {
        public int CustomerId { get; }
        public string IssueDescription { get; }
        public List<string> Tags { get; }

        public CreateServiceCaseCallCommand(int customerId, string issueDescription, List<string> tags)
        {
            CustomerId = customerId;
            IssueDescription = issueDescription;
            Tags = tags ?? new List<string>();
        }

        public override Task<bool> CanExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }

        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
