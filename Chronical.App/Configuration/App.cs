using Chronical.App.Services.Implementations.Old;
using Chronical.App.Services.Interfaces.Old;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Configuration
{
    public static class App
    {
        public static IServiceCollection ConfigureApp(this IServiceCollection services)
        {
            services.ConfigurePackages()
                .ConfigureServices();
            return services;
        }

        private static IServiceCollection ConfigurePackages(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(App).Assembly);
            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<IChapterService, ChapterService>()
                .AddScoped<IBookService, BookService>()
                .AddScoped<ICharacterService, CharacterService>();
            return services;
        }
    }
}
