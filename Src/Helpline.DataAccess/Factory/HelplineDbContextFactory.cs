using Helpline.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Factory
{
    public class HelplineDbContextFactory
    {
        private readonly DbContextOptions _options;

        public HelplineDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public HelplineContext Create()
        {
            return new HelplineContext(_options);
        }
    }
}
