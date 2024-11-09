﻿using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Helpline.Domain.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
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

        public UnitOfWork(HelplineContext context, ILogging logger, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            logging = logger;

            AddressRepo = new AddressRepository(context, logger);
            UserRepo = new ApplicationUserRepository(context, logger, userManager);
            CustomerRepo = new CustomerRepository(context, logger);
            EmployeeRepo = new EmployeeRepository(context, logger);
            TechnicianRepo = new TechnicianRepository(context, logger);
            DealershipContactRepo = new DealershipContactRepository(context, logger);
            RVRenterRepo = new RVRenterRepository(context, logger);
            this.userManager = userManager;
        }

        public async Task<bool> CompleteAsync(CancellationToken cancellationToken)
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
