﻿using Chronicle.Domain.Database;
using Chronicle.Domain.Database.Interfaces;
using Chronicle.Domain.Repositories.Implementations;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chronical.App.Configuration
{
    public static class Domain
    {
        public static IServiceCollection ConfigureChronicle(this IServiceCollection services)
        {
            services.ConfigureDb();
            services.ConfigureRepositories();
            return services;
        }

        public static IServiceCollection ConfigureDb(this IServiceCollection services)
        {
            services.AddDbContext<ChronicleDBContext>();
            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            var debug = true;

            if (debug)
            {
                services.AddScoped<ICommentRepository, CommentRepositoryInMemory>();
            }
            else
            {
                services.AddScoped<ICommentRepository, CommentRepository>();
            }

            return services;
        }
    }
}
