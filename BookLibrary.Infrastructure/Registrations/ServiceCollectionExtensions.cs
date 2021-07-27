
using BookLibrary.DAL.InMemory.Registrations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookLibrary.Infrastructure.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Here we could, eg. based on Configuration settings, load different DAL project to support multiple DBs types in production/testing.
            services.AddInMemoryDataAccessLayer();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
