using Chronicle.Entity.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Chronical.App.Configuration
{
    public static class Domain
    {
        public static IServiceCollection ConfigureDb(this IServiceCollection services)
        {
            services.AddDbContext<ChronicleDBContext>(
                options => options.UseInMemoryDatabase("ChronicleList"));
            return services;
        }
    }
}
