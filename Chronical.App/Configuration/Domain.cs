using Chronical.App.Services.Implementations;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories.Implementations;
using Chronicle.Domain.Repositories.Implementations.InMemory;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using Microsoft.EntityFrameworkCore;

namespace Chronical.App.Configuration
{
    public static class Domain
    {
        private static AppSettings appsettings;

        public static WebApplicationBuilder AppSettings(this WebApplicationBuilder webAppBuilder)
        {
            appsettings = webAppBuilder.Configuration.Get<AppSettings>();
            return webAppBuilder;
        }

        public static IServiceCollection ConfigureDomain(this IServiceCollection services)
        {
            services
                .ConfigureDb()
                .ConfigureRepositories();
            return services;
        }

        private static IServiceCollection ConfigureDb(this IServiceCollection services)
        {
            services.AddDbContext<ChronicleDbContext>(
                opt => opt.UseInMemoryDatabase(appsettings.ConnectionString!.DbName!)
                );
            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Comment>, CommentRepository>();
            services.AddSingleton<IRepository<Chapter>, ChapterRepository>();
            services.AddSingleton<IRepository<Book>, BookRepository>();
            services.AddSingleton<IRepository<Author>, AuthorRepository>();

            return services;
        }
    }
}
