using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Data.Repositories;
using Helpline.DataAccess.Outbox;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.CoreElements;
using Helpline.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Helpline.DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HelplineContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogging logging;
        public IAddressRepository AddressRepo { get; }
        public IApplicationUserRepository UserRepo { get; }
        public ICustomerRepository CustomerRepo { get; }
        public IEmployeeRepository EmployeeRepo { get; }
        public ITechnicianRepository TechnicianRepo { get; }
        public IDealershipContactRepository DealershipContactRepo { get; }
        public IRVRenterRepository RVRenterRepo { get; }

        public UnitOfWork(
            HelplineContext context,
            ILogging logging,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.logging = logging;
            this.userManager = userManager;

            AddressRepo = new AddressRepository(context, logging);
            UserRepo = new ApplicationUserRepository(context, logging, userManager);
            CustomerRepo = new CustomerRepository(context, logging);
            EmployeeRepo = new EmployeeRepository(context, logging);
            TechnicianRepo = new TechnicianRepository(context, logging);
            DealershipContactRepo = new DealershipContactRepository(context, logging);
            RVRenterRepo = new RVRenterRepository(context, logging);
        }

        public async Task<bool> CompleteAsync(CancellationToken cancellationToken)
        {
            try
            {
                ConvertDomainEventsToOutboxMessages();
                UpdateAuditableEntities();

                var result = await context.SaveChangesAsync(cancellationToken);
                return result > 0;
            }
            catch (Exception ex)
            {
                logging.LogError(ex, $"{nameof(CompleteAsync)}: Message: {ex.Message} InnerException: {ex.InnerException}");
                throw new ArgumentException(ex.Message);
            }
        }

        public void Dispose()
        {
            context.Dispose();
            userManager.Dispose();
        }

        private void ConvertDomainEventsToOutboxMessages()
        {
            var outboxMessages = context.ChangeTracker
                .Entries<AggregateRoot>()
                .Select(x => x.Entity)
                .SelectMany(aggregateRoot =>
                {
                    IReadOnlyCollection<IDomainEvent> domainEvents = aggregateRoot.GetDomainEvents();

                    aggregateRoot.ClearDomainEvents();

                    return domainEvents;
                })
                .Select(domainEvent => new OutboxMessage()
                {
                    Id = Guid.NewGuid(),
                    OccuredOn = DateTime.UtcNow,
                    Type = domainEvent.GetType().Name,
                    Content = JsonConvert.SerializeObject(
                        domainEvent,
                        new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.All,
                        })
                })
                .ToList();
        }

        private void UpdateAuditableEntities()
        {
            IEnumerable<EntityEntry<IAuditableEntity>> entries = context.ChangeTracker.Entries<IAuditableEntity>();

            foreach (EntityEntry<IAuditableEntity> entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(a => a.CreatedOn)
                        .CurrentValue = DateTime.UtcNow;

                    entry.Property(a => a.IsActive)
                        .CurrentValue = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(a => a.ModifiedOn)
                        .CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}
