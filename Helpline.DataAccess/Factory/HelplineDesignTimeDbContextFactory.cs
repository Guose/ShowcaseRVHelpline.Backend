using Helpline.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Helpline.DataAccess.Factory
{
    public class HelplineDesignTimeDbContextFactory : IDesignTimeDbContextFactory<HelplineContext>
    {
        public HelplineContext CreateDbContext(string[]? args = null)
        {
            HelplineContext helplineCtx = new(new DbContextOptionsBuilder().Options);

            var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            if (args!.Length > 0)
            {
                for (int i = 0; i < args!.Length; i++)
                {
                    if (args[i] == "SqlServer")
                    {                       

                        var connectionString = configuration.GetConnectionString("SqlServerConnection");

                        helplineCtx = new HelplineContext(new DbContextOptionsBuilder()
                            .UseSqlServer(connectionString)
                            .EnableSensitiveDataLogging()
                            .Options);
                    }
                    else if (args[i] == "pgAdmin")
                    {
                        var connectionString = configuration.GetConnectionString("PgAdminConnection");

                        helplineCtx = new HelplineContext(new DbContextOptionsBuilder()
                            .UseNpgsql(connectionString)
                            .EnableSensitiveDataLogging()
                            .Options);
                    }
                }
            }
            else
            {
                throw new ArgumentNullException($"{nameof(HelplineDesignTimeDbContextFactory)} - {nameof(CreateDbContext)}", "\'args\' parameter cannot be null.");
            }

            return helplineCtx;
        }
    }
}
