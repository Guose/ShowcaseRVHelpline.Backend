using Helpline.Common.Interfaces;
using Helpline.Common.Logging;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Data.Repositories;

namespace Helpline.Domain.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly HelplineContext context;
        private readonly ILogging logging;
        public IAddressRepository AddressRepo { get; }
        public IApplicationUserRepository UserRepo { get; }
        public ICustomerRepository CustomerRepo { get; }
        public IEmployeeRepository EmployeeRepo { get; }
        public ITechnicianRepository TechnicianRepo { get; }
        public IDealershipContactRepository DealershipContactRepo { get; }
        public IRVRenterRepository RVRenterRepo { get; }

        public UnitOfWork(HelplineContext context, ILogging logger)
        {
            this.context = context;
            logging = logger;

            AddressRepo = new AddressRepository(context, logger);
            UserRepo = new ApplicationUserRepository(context, logger);
            CustomerRepo = new CustomerRepository(context, logger);
            EmployeeRepo = new EmployeeRepository(context, logger);
            TechnicianRepo = new TechnicianRepository(context,logger);
            DealershipContactRepo = new DealershipContactRepository(context, logger);
            RVRenterRepo = new RVRenterRepository(context, logger);
        }

        public async Task<bool> CompleteAsync()
        {
            try
            {
                var result = await context.SaveChangesAsync();
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
            //throw new NotImplementedException();
        }
    }
}
