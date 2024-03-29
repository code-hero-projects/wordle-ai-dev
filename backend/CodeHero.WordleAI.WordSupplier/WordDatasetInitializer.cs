﻿using CodeHero.WordleAI.Domain.Repositories;
using CodeHero.WordleAI.Domain.Services;
using CodeHero.WordleAI.WordSupplier.Services.WordsClassifier;
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

            await AddWordsToDatabase(serviceProvider, wordRepository);
            
            return host;
        }

        private static async Task AddWordsToDatabase(IServiceProvider serviceProvider, IWordRepository wordRepository)
        {
            var wordFetcher = serviceProvider.GetService<IWordsFetcher>();
            var wordClassifier = serviceProvider.GetService<IWordsClassifier>();

            var words = await wordFetcher.FetchWordsAsync();
            words = await wordClassifier.ClassifyAsync(words);

            words = await new DistinctMostUsedLettersClassifer().ClassifyAsync(words);

            foreach (var word in words)
            {
                await wordRepository.AddAsync(word);
            }

            await wordRepository.SaveChangesAsync();
        }
    }
}
