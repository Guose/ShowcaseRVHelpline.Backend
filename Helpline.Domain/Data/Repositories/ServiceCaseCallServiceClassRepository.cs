﻿using Helpline.Common.Interfaces;
using Helpline.Common.Models.Associations;
using Helpline.DataAccess.Context;
using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data.Repositories
{
    public class ServiceCaseCallServiceClassRepository(HelplineContext context, ILogging logging) :
        BaseRepository<ServiceCaseCallServiceClass, HelplineContext, int>(context, logging), IServiceCaseCallServiceClassRepository
    {
    }
}
