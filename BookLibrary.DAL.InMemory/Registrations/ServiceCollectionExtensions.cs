using BookLibrary.Core.Database;
using BookLibrary.Core.UnitOfWork;
using BookLibrary.DAL.InMemory.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.DAL.InMemory.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInMemoryDataAccessLayer(this IServiceCollection services)
        {
            services.AddDbContext<BookLibraryDbContext>(opts => opts.UseInMemoryDatabase(databaseName: "BookLibrary"));
            // Using UnitOfWork pattern to (possibly) encapsulate multiple operations inside single command handler
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            // Addding transient DbInitializer which is triggered from StartUp class
            services.AddTransient<IDbInitializer, DbInitializer>();
        }
    }
}
