using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Outbox;
using Helpline.Domain.Models.CoreElements;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;

namespace Helpline.Core.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class ProcessOutboxMessageJob : IJob
    {
        private readonly HelplineContext dbContext;
        private readonly IPublisher publisher;
        private readonly ILogging logging;

        public ProcessOutboxMessageJob(HelplineContext dbContext, IPublisher publisher, ILogging logging)
        {
            this.dbContext = dbContext;
            this.publisher = publisher;
            this.logging = logging;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                List<OutboxMessage> messages = await dbContext.OutboxMessages
                .Where(m => m.ProcessedOn == null)
                .Take(20)
                .ToListAsync(context.CancellationToken);

                foreach (OutboxMessage outboxMessage in messages)
                {
                    IDomainEvent? domainEvent = JsonConvert
                        .DeserializeObject<IDomainEvent>(
                            outboxMessage.Content,
                            new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.All
                            });

                    if (domainEvent is null)
                    {
                        continue;
                    }

                    await publisher.Publish(domainEvent, context.CancellationToken);

                    outboxMessage.ProcessedOn = DateTime.UtcNow;
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logging.LogError(
                    ex,
                    $"{nameof(ProcessOutboxMessageJob)}.{Execute}: " +
                        $"Message: {ex.Message} " +
                            $"InnerException: {ex.InnerException}");

                throw new ArgumentException(ex.Message);
            }
        }
    }
}
