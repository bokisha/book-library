
using BookLibrary.DAL.InMemory.Registrations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookLibrary.Infrastructure.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            // Here we could, eg. based on Configuration settings, load different DAL project to support multiple DBs providers in production and/or testing.
            services.AddInMemoryDataAccessLayer();

            // I've used mediatr library for Mediator pattern to simplify solution since MediatR library is fairly easy to understand(as well Mediator pattern :)).
            // By using Mediator pattern we can eg. easily support introduction of Microservices architecture
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
