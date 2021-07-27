using BookLibrary.Api.Models;
using BookLibrary.Api.Models.Converters;
using BookLibrary.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Api.Registrations
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterModelConverters(this IServiceCollection services)
        {
            services.AddSingleton<IEntityModelConverter<Book, BookModel>, BookModelConverter>();
            services.AddSingleton<IEntityModelConverter<Author, SelectItemByIdModel>, AuthorSelectItemModelConverter>();
        }
    }
}
