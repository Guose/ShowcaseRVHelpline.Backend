﻿using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class KnowledgeBaseLibraryRepository(HelplineContext context, ILogging logging) :
        GenericRepository<KnowledgeBaseLibrary, HelplineContext>(context, logging), IKnowledgeBaseLibraryRepository
    {
    }
}
