using BookLibrary.Core.Entities;
using BookLibrary.Core.Models;
using BookLibrary.Models;
using BookLibrary.Models.Converters;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModelConverters(this IServiceCollection services)
        {
            services.AddSingleton<IEntityModelConverter<Book, BookModel>, BookModelConverter>();
            services.AddSingleton<IEntityModelConverter<Author, SelectItemByIdModel>, AuthorSelectItemModelConverter>();

            return services;
        }
    }
}
