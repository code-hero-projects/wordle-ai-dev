using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeHero.WordleAI.Application.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
