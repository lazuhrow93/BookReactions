using Chronical.App.Services.Implementations;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Repositories.Implementations;
using Chronicle.Domain.Repositories.Implementations.InMemory;
using Chronicle.Domain.Repositories.Interfaces;
using Chronicle.Entity.Database;

namespace Chronical.App.Configuration
{
    public static class Domain
    {
        public static IServiceCollection ConfigureDomain(this IServiceCollection services)
        {
            services.ConfigureDb();
            services.ConfigureRepositories();
            return services;
        }

        private static IServiceCollection ConfigureDb(this IServiceCollection services)
        {
            services.AddDbContext<ChronicleDBContext>();
            return services;
        }

        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            var debug = true;

            if (debug)
            {
                services.AddSingleton<ICommentRepository, CommentRepositoryInMemory>();
                services.AddSingleton<IChapterRepository, ChapterRepositoryInMemory>();
                services.AddSingleton<IBookRepository, BookRepositoryInMemory>();
            }
            else
            {
                services.AddSingleton<ICommentRepository, CommentRepository>();
                services.AddSingleton<IChapterRepository, ChapterRepository>();
                services.AddSingleton<IBookRepository, BookRepository>();
            }

            return services;
        }
    }
}
