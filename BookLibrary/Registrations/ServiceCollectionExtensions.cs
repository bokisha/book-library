using BookLibrary.Core;
using BookLibrary.Core.Entities;
using BookLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModelConverters(this IServiceCollection services)
        {
            services.AddSingleton<IEntityModelConverter<Book, BookModel>, BookModelConverter>();

            return services;
        }
    }
}
