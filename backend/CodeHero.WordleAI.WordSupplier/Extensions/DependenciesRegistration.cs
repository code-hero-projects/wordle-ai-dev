using CodeHero.WordleAI.Domain.Services;
using CodeHero.WordleAI.WordSupplier.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.WordleAI.WordSupplier.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddWordSupplierDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IWordsFetcher, BestWordlListWordSupplier>();
            services.AddSingleton<IWordsClassifier, DistinctLetterClassifier>();

            return services;
        }
    }
}
