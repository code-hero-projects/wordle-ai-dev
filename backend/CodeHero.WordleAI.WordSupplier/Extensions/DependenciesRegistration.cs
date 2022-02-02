using CodeHero.WordleAI.Domain.Services;
using CodeHero.WordleAI.WordSupplier.Services.WordsClassifier;
using CodeHero.WordleAI.WordSupplier.Services.WordsFetcher;
using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.WordleAI.WordSupplier.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddWordSupplierDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IWordsFetcher, BestWordlListWordSupplier>();
            services.AddSingleton<IWordsClassifier, DistinctMostUsedLettersClassifer>();

            return services;
        }
    }
}
