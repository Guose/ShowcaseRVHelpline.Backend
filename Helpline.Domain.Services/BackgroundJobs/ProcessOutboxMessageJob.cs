using Quartz;

namespace Helpline.Domain.Services.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxMessageJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
