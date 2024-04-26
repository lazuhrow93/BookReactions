using Chronicle.Domain.Repositories.Implementations;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;
using Microsoft.EntityFrameworkCore;

namespace Chronical.App.Configuration
{
    public static class Domain
    {
        public static AppSettings appsettings;

        public static IServiceCollection ConfigureDomain(this IServiceCollection services)
        {
            services
                .ConfigureDb()
                .ConfigureRepositories();
            return services;
        }

        public static WebApplicationBuilder AppSettings(this WebApplicationBuilder webAppBuilder)
        {
            appsettings = webAppBuilder.Configuration.Get<AppSettings>();
            return webAppBuilder;
        }

        private static IServiceCollection ConfigureDb(this IServiceCollection services)
        {
            services.AddDbContext<ChronicleDbContext>(
                opt => opt.UseInMemoryDatabase("TestDb")
                );
            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICommentRepository, CommentRepository>()
                .AddScoped<IChapterRepository, ChapterRepository>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IAuthorRepository, AuthorRepository>()
                .AddScoped<ICharacterRepository, CharacterRepository>();

            return services;
        }
    }
}
