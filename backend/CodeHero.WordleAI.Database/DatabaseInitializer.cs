using CodeHero.WordleAI.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodeHero.WordleAI.Database
{
    public static class DatabaseInitializer
    {
        public static IHost InitialiseDatabase(this IHost host)
        {
            using var serviceScope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var retryDelay = serviceProvider.GetService<DatabaseConfiguration>().InitializeRetryDelay;

            var logger = serviceProvider.GetService<ILogger<DatabaseContext>>();

            logger.LogInformation("Initializing database");

            var ready = false;

            while (!ready)
            {
                try
                {
                    var dbContext = serviceProvider.GetService<DatabaseContext>();
                    dbContext.Database.Migrate();

                    ready = true;
                    logger.LogInformation("Initializing complete");
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Initializing failed. Trying again after delay ({0})", retryDelay);
                    Thread.Sleep(retryDelay);
                }
            }

            return host;
        }
    }
}
