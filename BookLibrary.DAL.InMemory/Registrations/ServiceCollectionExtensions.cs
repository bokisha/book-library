using BookLibrary.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.DAL.InMemory.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInMemoryDataAccessLayer(this IServiceCollection services)
        {
            services.AddDbContext<BookLibraryDbContext>(opts => opts.UseInMemoryDatabase(databaseName: "BookLibrary"));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
