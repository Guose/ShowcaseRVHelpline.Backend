using Helpline.DataAccess.Context;
using Helpline.DataAccess.Factory;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Helpers
{
    public class DbContextServiceHelpler
    {
        private readonly HelplineDbContextFactory helplineDbContextFactory;

        public DbContextServiceHelpler(HelplineDbContextFactory helplineDbContextFactory)
        {
            this.helplineDbContextFactory = helplineDbContextFactory;
        }

        public async Task MigrateDatabaseAsnyc()
        {
            using HelplineContext helplineCtx = helplineDbContextFactory.Create();
            await helplineCtx.Database.MigrateAsync();
        }
    }
}
