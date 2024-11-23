using Helpline.DataAccess.Context;
using Helpline.DataAccess.Outbox;
using Helpline.Domain.Models.CoreElements;
using Helpline.Services.Abstractions.Messaging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Helpline.Core.Idempotence
{
    public sealed class IdempotentDomainEventHandler<TDomainEvent> : IDomainEventHandler<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        private readonly INotificationHandler<TDomainEvent> decorated;
        private readonly HelplineContext dbContext;

        public IdempotentDomainEventHandler(INotificationHandler<TDomainEvent> decorated, HelplineContext context)
        {
            this.decorated = decorated;
            dbContext = context;
        }

        public async Task Handle(TDomainEvent notification, CancellationToken cancellationToken)
        {
            string consumer = decorated.GetType().Name;


            if (await dbContext.Set<OutboxMessageConsumer>()
                    .AnyAsync(
                        outboxMessageConsumer =>
                            outboxMessageConsumer.Id == notification.Id &&
                            outboxMessageConsumer.Name == consumer,
                        cancellationToken))
            {
                return;
            }

            await decorated.Handle(notification, cancellationToken);

            dbContext.Set<OutboxMessageConsumer>()
                .Add(new OutboxMessageConsumer
                {
                    Id = notification.Id,
                    Name = consumer
                });

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
