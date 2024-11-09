using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class TagRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Tag, HelplineContext, int>(context, logging), ITagRepository
    {
    }
}
