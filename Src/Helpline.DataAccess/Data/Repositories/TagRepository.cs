using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class TagRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Tag, HelplineContext, int>(context, logging), ITagRepository
    {
    }
}
