﻿using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Models.Entities;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class DealershipRepository(HelplineContext context, ILogging logging) :
        BaseRepository<Dealership, HelplineContext, int>(context, logging), IDealershipRepository
    {
    }
}