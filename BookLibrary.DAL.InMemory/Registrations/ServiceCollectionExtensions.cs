
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.DAL.InMemory.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryDataAccessLayer(this IServiceCollection services)
        {
            services.AddDbContext<IBookLibraryDbContext, BookLibraryDbContext>(opts => opts.UseInMemoryDatabase(databaseName: "BookLibrary"));

            return services;
        }
    }
}
