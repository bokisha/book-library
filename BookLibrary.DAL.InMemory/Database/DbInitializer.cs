using System.Linq;
using BookLibrary.Core.Database;
using BookLibrary.Core.Entities;
using BookLibrary.Core.Enums;

namespace BookLibrary.DAL.InMemory.Database
{
    public class DbInitializer : IDbInitializer
    {
        private readonly BookLibraryDbContext _context;

        public DbInitializer(BookLibraryDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            var danBrown = new Author { Id = 1, FirstName = "Dan", LastName = "Brown"};
            var ferencMolnar = new Author { Id = 2, FirstName = "Ferenc", LastName = "Molnár" };
            var georgeMartin = new Author { Id = 3, FirstName = "George", LastName = "R. R. Martin" };
            var georgeOrwell = new Author { Id = 4, FirstName = "George", LastName = "Orwell" };
            var hermannHesse = new Author { Id = 5, FirstName = "Hermann", LastName = "Hesse" };
            var robinSharma = new Author { Id = 6, FirstName = "Robin", LastName = "Sharma" };

            if (!_context.Books.Any())
            {
                _context.Books.AddRange(
                  new Book
                  {
                      Id = 1,
                      Title = "The Da Vinci Code",
                      Description = "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown.",
                      Genre = Genre.Mystery,
                      Author = danBrown
                  },
                  new Book
                  {
                      Id = 2,
                      Title = "Angels & Demons",
                      Description = "Angels & Demons is a 2000 bestselling mystery-thriller " +
                                                                              "novel written by American author Dan Brown and published by Pocket Books and then by Corgi Books.",
                      Genre = Genre.Mystery,
                      Author = danBrown
                  },
                  new Book
                  {
                      Id = 3,
                      Title = "The Paul Street Boys",
                      Description = "The Paul Street Boys is a youth novel by the Hungarian writer Ferenc Molnár, first published in 1906",
                      Genre = Genre.Novel,
                      Author = ferencMolnar
                  },
                  new Book
                  {
                      Id = 4,
                      Title = "A Song of Ice and Fire",
                      Description = "A Song of Ice and Fire is a series of epic fantasy novels by the American novelist and screenwriter George R. R. Martin.",
                      Genre = Genre.Fantasy,
                      Author = georgeMartin
                  },
                  new Book
                  {
                      Id = 5,
                      Title = "1984 (Nineteen Eighty-Four)",
                      Description = "Nineteen Eighty-Four: A Novel, often referred to as 1984, is a dystopian social " +
                      "science fiction novel by the English novelist George Orwell",
                      Genre = Genre.Novel,
                      Author = georgeOrwell
                  },
                  new Book
                  {
                      Id = 6,
                      Title = "Steppenwolf",
                      Description = "The novel was named after the German name for the steppe wolf. " +
                                    "The story in large part reflects a profound crisis in Hesse's spiritual world during the 1920s.",
                      Genre = Genre.Autobiographical,
                      Author = hermannHesse
                  },
                  new Book
                  {
                      Id = 7,
                      Title = "The Monk Who Sold His Ferrari ",
                      Description = "The Monk Who Sold His Ferrari is a self-help book by Robin Sharma, a writer and motivational speaker. " +
                                    "The book is a business fable derived from Sharma's personal experiences after leaving his " +
                                    "career as a litigation lawyer at the age of 25.",
                      Genre = Genre.Fable,
                      Author = robinSharma
                  }
                  );
            }

            _context.SaveChangesAsync();
        }
    }
}
