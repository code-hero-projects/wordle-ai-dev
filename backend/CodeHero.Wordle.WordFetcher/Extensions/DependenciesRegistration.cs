using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeHero.Wordle.WordFetcher.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddWordFetcherDependencies(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            return services;
        }
    }
}
