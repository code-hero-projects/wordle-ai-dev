using CodeHero.Wordle.Database.Configuration;
using CodeHero.Wordle.Database.Mappings;
using CodeHero.Wordle.Database.Mappings.CosmosDb;
using CodeHero.Wordle.Database.Mappings.PostrgeSql;
using CodeHero.Wordle.Database.Repositories;
using CodeHero.Wordle.Domain.Model;
using CodeHero.Wordle.Domain.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.Wordle.Database.Extensions
{
    public static class DependenciesRegistration
    {
        private const string PostgreSqlAssembly = "CodeHero.WordleAI.Migrations.PostgreSql";

        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            var databaseOptions = configurationSection.Get<DatabaseConfiguration>();

            switch (databaseOptions.Type)
            {
                case DatabaseType.PostgreSql:
                    AddPostgreSql(services, databaseOptions);
                    break;
                case DatabaseType.CosmosDb:
                    AddCosmosDbAsync(services, databaseOptions).Wait();
                    break;
                default:
                    throw new ArgumentException("Database configuration is missing.");
            }

            services
                .AddSingleton(databaseOptions)
                .AddSingleton<EntitiesConfiguration>()
                .AddScoped<IWordRepository, WordRepository>();

            return services;
        }

        private static void AddPostgreSql(IServiceCollection services, DatabaseConfiguration databaseOptions)
        {
            services
                .AddSingleton<IEntityTypeConfiguration<Word>, PostgreSqlWordMapping>()
                .AddDbContext<DatabaseContext>(dbConfig => dbConfig.UseNpgsql(databaseOptions.ConnectionString, x => x.MigrationsAssembly(PostgreSqlAssembly)));
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
