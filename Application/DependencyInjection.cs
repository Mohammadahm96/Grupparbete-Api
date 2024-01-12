using FluentValidation;
using Infrastructure.Interface;
using Infrastructure.Repositories.AnimalRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}