using Chronical.App.Services.Implementations;
using Chronical.App.Services.Interfaces;

namespace Chronical.App.Configuration
{
    public static class App
    {
        public static IServiceCollection ConfigureApp(this IServiceCollection services)
        {
            services.ConfigurePackages();
            services.ConfigureServices();
            return services;
        }

        private static IServiceCollection ConfigurePackages(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(App).Assembly);
            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ICommentsService, CommentsService>();
            services.AddSingleton<IChapterService, ChapterService>();
            services.AddSingleton<IBookService, BookService>();
            return services;
        }
    }
}
