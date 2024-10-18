using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class ServiceCaseRepository(HelplineContext context, ILogging logging) :
        GenericRepository<ServiceCase, HelplineContext>(context, logging), IServiceCaseRepository
    {
        public Task<ServiceCase?> GetServiceCaseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntityAsync(ServiceCase serviceCase)
        {
            throw new NotImplementedException();
        }
    }
}
