using Helpline.Common.Interfaces;
using Helpline.Common.Models.Associations;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class ServiceCaseTagRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseTag, HelplineContext, int>(context, logging), IServiceCaseTagRepository
    {
    }
}
