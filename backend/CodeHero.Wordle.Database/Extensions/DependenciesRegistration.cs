using CodeHero.Wordle.Database.Configuration;
using CodeHero.Wordle.Database.Mappings.CosmosDb;
using CodeHero.Wordle.Domain.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.Wordle.Database.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var databaseOptions = configurationSection.Get<DatabaseConfiguration>();

            switch (databaseOptions.Type)
            {
                case DatabaseType.CosmosDb:
                    AddCosmosDbAsync(services, databaseOptions).Wait();
                    break;
                default:
                    throw new ArgumentException("Database configuration is missing.");
            }

            return services;
        }

        private static async Task AddCosmosDbAsync(IServiceCollection services, DatabaseConfiguration databaseOptions)
        {
            services
                .AddSingleton<IEntityTypeConfiguration<Word>, CosmosDbWordMapping>()
                .AddDbContext<DatabaseContext>(dbConfig => dbConfig.UseCosmos(databaseOptions.ConnectionString, databaseOptions.DatabaseName));

            var cosmosClient = new CosmosClient(databaseOptions.ConnectionString);
            var database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseOptions.DatabaseName);

            for (var index = 0; index < databaseOptions.Containers.Length; ++index)
            {
                var container = databaseOptions.Containers[index];
                var partitionKey = databaseOptions.PartitionKeys[index];

                await database.Database.CreateContainerIfNotExistsAsync(container, partitionKey);
            }
        }
    }
}
