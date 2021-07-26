using BookLibrary.Core;
using BookLibrary.Core.Entities;
using BookLibrary.Core.Enums;
using System;

namespace BookLibrary.Models
{
    public class BookModel : IViewModel
    {
        public int Id { get; set; }

        public DateTime ModifiedUtc { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public string GenreString { get; set; }
        public int AuthorId { get; set; }
        public string AuthorString { get; set; }
    }

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
                GenreString = "TODO",
                AuthorId = entity.AuthorId,
                AuthorString = entity.Author.GetFullName()
            };
        }
    }
}
