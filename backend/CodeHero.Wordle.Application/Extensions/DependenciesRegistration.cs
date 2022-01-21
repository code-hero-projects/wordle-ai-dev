using Microsoft.Extensions.DependencyInjection;

namespace CodeHero.Wordle.Application.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
