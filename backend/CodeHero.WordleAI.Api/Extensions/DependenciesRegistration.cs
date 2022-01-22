using System.Reflection;

namespace CodeHero.WordleAI.Api.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(o => o.AddPolicy(ApiConstants.AllowAllCorsPolicy, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services
                .AddRouting(options => options.LowercaseUrls = true)
                .AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
