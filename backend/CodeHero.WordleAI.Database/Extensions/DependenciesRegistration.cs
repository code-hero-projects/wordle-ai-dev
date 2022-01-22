using CodeHero.WordleAI.Database.Configuration;
using CodeHero.WordleAI.Database.Mappings;
using CodeHero.WordleAI.Database.Mappings.PostgreSql;
using CodeHero.WordleAI.Database.Repositories;
using CodeHero.WordleAI.Domain.Model;
using CodeHero.WordleAI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.WordleAI.Database.Extensions
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
    }
}
