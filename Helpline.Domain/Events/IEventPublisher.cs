﻿namespace Helpline.Domain.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken) where T : class;
    }
}
