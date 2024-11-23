using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities.Associations;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceCaseTagRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseTag, HelplineContext, int>(context, logging), IServiceCaseTagRepository
    {
    }
}
