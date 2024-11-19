using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities.Associations;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class ServiceCaseTagRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseTag, HelplineContext, int>(context, logging), IServiceCaseTagRepository
    {
    }
}
