using CodeHero.Wordle.Domain.Services;
using CodeHero.Wordle.WordFetcher.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.Wordle.WordFetcher.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddWordFetcherDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IWordFetcher, BestWordlListWordFetcher>();

            return services;
        }
    }
}
