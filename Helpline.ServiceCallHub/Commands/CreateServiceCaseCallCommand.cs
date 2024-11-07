namespace Helpline.ServiceCallHub.Commands
{
    public class CreateServiceCaseCallCommand
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
    }
}
