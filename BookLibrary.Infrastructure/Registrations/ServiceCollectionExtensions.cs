
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
            // Ive purposely extracted Dal.InMemory project so i could (eg. based on Configuration settings)
            // load different DAL project to support other DBs providers
            services.AddInMemoryDataAccessLayer();

            // I've used mediatr library for Mediator pattern to simplify solution since MediatR library is fairly easy to understand(as well Mediator pattern :)).
            // By using Mediator pattern i have decoupled Controllers from Infrastructure and also 
            // by using Mediator app can be easily expanded to support microservices and event driven methodology
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
