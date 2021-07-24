using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Infrastructure.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<BookLibraryDbContext>(opts => opts.UseInMemoryDatabase(databaseName: "BookLibrary"));

            return services;
        }
    }
}
