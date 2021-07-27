using BookLibrary.Core.Entities;

namespace BookLibrary.Api.Models.Converters
{
    public class BookModelConverter : IEntityModelConverter<Book, BookModel>
    {
        public BookModel ConvertToModel(Book entity)
        {
            return new BookModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Genre = entity.Genre,
                GenreString = entity.Genre.ToString(),
                AuthorId = entity.AuthorId,
                AuthorString = entity.Author.GetFullName(),
                ModifiedUtc = entity.ModifiedUtc
            };
        }
    }
}
