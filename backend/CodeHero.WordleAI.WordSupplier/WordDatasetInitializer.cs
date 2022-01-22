using CodeHero.WordleAI.Domain.Repositories;
using CodeHero.WordleAI.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeHero.WordleAI.WordSupplier
{
    public static class WordDatasetInitializer
    {
        public static async Task<IHost> InitialiseWordDataSet(this IHost host)
        {
            using var serviceScope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var wordRepository = serviceProvider.GetService<IWordRepository>();
            var savedWords = await wordRepository.ListAsync();

            if (savedWords.LongCount() > 0)
            {
                return host;
            }

            var wordFetcher = serviceProvider.GetService<IWordsFetcher>();
            var words = await wordFetcher.FetchWordsAsync();

            foreach (var word in words)
            {
                await wordRepository.AddAsync(word);
            }

            await wordRepository.SaveChangesAsync();

            return host;
        }
    }
}
