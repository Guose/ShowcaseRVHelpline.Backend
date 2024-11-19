using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.DataAccess.Data.Repositories
{
    public class KnowledgeBaseLibraryRepository(HelplineContext context, ILogging logging) :
        BaseRepository<KnowledgeBaseLibrary, HelplineContext, int>(context, logging), IKnowledgeBaseLibraryRepository
    {
    }
}
