using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Models.Entities;

namespace Helpline.DataAccess.Data.Repositories
{
    public class KnowledgeBaseLibraryRepository(HelplineContext context, ILogging logging) :
        BaseRepository<KnowledgeBaseLibrary, HelplineContext, int>(context, logging), IKnowledgeBaseLibraryRepository
    {
    }
}
