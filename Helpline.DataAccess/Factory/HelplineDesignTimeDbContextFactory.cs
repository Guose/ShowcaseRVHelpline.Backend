using Helpline.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helpline.DataAccess.Factory
{
    public class HelplineDesignTimeDbContextFactory : IDesignTimeDbContextFactory<HelplineContext>
    {
        public HelplineContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettingsDataAccess.json")
                            .Build();

            // Create a DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<HelplineContext>();

            // Default to SqlServer if no args are provided
            if (args == null || args.Length == 0)
            {
                // Use SQL Server as default if no argument is passed
                var connectionString = configuration.GetConnectionString("SqlServerConnection");

                optionsBuilder.UseSqlServer(connectionString)
                              .EnableSensitiveDataLogging(false)
                              .LogTo(Console.WriteLine, LogLevel.Information);
            }
            else
            {
                // Check arguments for specific database
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "SqlServer")
                    {
                        var connectionString = configuration.GetConnectionString("SqlServerConnection");

                        optionsBuilder.UseSqlServer(connectionString)
                                      .EnableSensitiveDataLogging()
                                      .LogTo(Console.WriteLine, LogLevel.Information);
                    }
                    else if (args[i] == "pgAdmin")
                    {
                        var connectionString = configuration.GetConnectionString("PgAdminConnection");

                        optionsBuilder.UseNpgsql(connectionString)
                                      .EnableSensitiveDataLogging()
                                      .LogTo(Console.WriteLine, LogLevel.Information);
                    }
                    // You can add more database providers here if needed
                }
            }

            // Create and return the HelplineContext with the configured options
            return new HelplineContext(optionsBuilder.Options);
        }
    }
}
