﻿using Helpline.Common.Interfaces;
using Helpline.Common.Models;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class RVRentalRepository(HelplineContext context, ILogging logging) :
        BaseRepository<RVRental, HelplineContext>(context, logging), IRVRentalRepository
    {
    }
}
