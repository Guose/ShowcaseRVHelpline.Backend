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
        public IAddressRepository AddressRepo { get; }
        public IApplicationUserRepository UserRepo { get; }
        public ICustomerRepository CustomerRepo { get; }
        public IEmployeeRepository EmployeeRepo { get; }
        public ITechnicianRepository TechnicianRepo { get; }

        public UnitOfWork(HelplineContext context, ILogging logger)
        {
            this.context = context;
            logger = new Logging();

            AddressRepo = new AddressRepository(context, logger);
            UserRepo = new ApplicationUserRepository(context, logger);
            CustomerRepo = new CustomerRepository(context, logger);
            EmployeeRepo = new EmployeeRepository(context, logger);
            TechnicianRepo = new TechnicianRepository(context,logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
