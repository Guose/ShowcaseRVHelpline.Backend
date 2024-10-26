using Helpline.Domain.Commands;
using Helpline.ServiceCallHub.Commands;

namespace Helpline.ServiceCallHub.Services
{
    public class ServiceCaseCallService
    {
        private readonly ICommandHandler<CreateServiceCaseCallCommand> commandHandler;

        public ServiceCaseCallService(ICommandHandler<CreateServiceCaseCallCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public async Task CreateServiceCaseCallAsync(int customerId, string issueDescription, List<string> tags)
        {
            var command = new CreateServiceCaseCallCommand(customerId, issueDescription, tags);
            await commandHandler.HandleAsync(command);
        }
    }
}
