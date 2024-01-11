﻿using Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<JWTtokenGenerator>();

            // add services for other Interfaces and responsive Repositories

            // services.AddScoped<IUserRepository, UserRepository>();

            // Add service for DbContext



            return services;
        }
    }
}