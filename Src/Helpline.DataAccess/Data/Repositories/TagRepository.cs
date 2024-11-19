using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class TagRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Tag, HelplineContext, int>(context, logging), ITagRepository
    {
    }
}
