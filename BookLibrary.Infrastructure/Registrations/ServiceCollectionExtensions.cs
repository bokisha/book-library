using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookLibrary.Infrastructure.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<IBookLibraryDbContext, BookLibraryDbContext>(opts => opts.UseInMemoryDatabase(databaseName: "BookLibrary"));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
