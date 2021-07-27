using BookLibrary.Core.Entities;
using BookLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookLibrary.DAL.InMemory
{
    public static class DbSeeder
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            var seedingDateTime = DateTime.UtcNow;

            var author1 = new Author { Id = 1, FirstName = "Dan", LastName = "Brown", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };
            var author2 = new Author { Id = 2, FirstName = "Ferenc", LastName = "Molnár", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };
            var author3 = new Author { Id = 3, FirstName = "George", LastName = "R. R. Martin", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };
            var author4 = new Author { Id = 4, FirstName = "George", LastName = "Orwell", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };
            var author5 = new Author { Id = 5, FirstName = "Hermann", LastName = "Hesse", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };
            var author6 = new Author { Id = 6, FirstName = "Robin", LastName = "Sharma", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };

            modelBuilder.Entity<Author>().HasData(author1, author2, author3, author4, author5, author6);


            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Da Vinci Code",
                    Description = "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown.",
                    Genre = Genre.Mystery,
                    CreatedUtc = seedingDateTime,
                    ModifiedUtc = seedingDateTime,
                    AuthorId = author1.Id
                },
                new Book
                {
                    Id = 2,
                    Title = "Angels & Demons",
                    Description = "Angels & Demons is a 2000 bestselling mystery-thriller " +
                                                                            "novel written by American author Dan Brown and published by Pocket Books and then by Corgi Books.",
                    Genre = Genre.Mystery,
                    CreatedUtc = seedingDateTime,
                    ModifiedUtc = seedingDateTime,
                    AuthorId = author1.Id
                },
                new Book
                {
                    Id = 3,
                    Title = "The Paul Street Boys",
                    Description = "The Paul Street Boys is a youth novel by the Hungarian writer Ferenc Molnár, first published in 1906",
                    Genre = Genre.Novel,
                    CreatedUtc = seedingDateTime,
                    ModifiedUtc = seedingDateTime,
                    AuthorId = author2.Id
                },
                new Book
                {
                    Id = 4,
                    Title = "A Song of Ice and Fire",
                    Description = "A Song of Ice and Fire is a series of epic fantasy novels by the American novelist and screenwriter George R. R. Martin.",
                    Genre = Genre.Fantasy,
                    CreatedUtc = seedingDateTime,
                    ModifiedUtc = seedingDateTime,
                    AuthorId = author3.Id
                },
                new Book
                {
                    Id = 5,
                    Title = "1984 (Nineteen Eighty-Four)",
                    Description = "Nineteen Eighty-Four: A Novel, often referred to as 1984, is a dystopian social " +
                    "science fiction novel by the English novelist George Orwell",
                    Genre = Genre.Novel,
                    CreatedUtc = seedingDateTime,
                    ModifiedUtc = seedingDateTime,
                    AuthorId = author4.Id
                },
                new Book
                {
                    Id = 6,
                    Title = "Steppenwolf",
                    Description = "The novel was named after the German name for the steppe wolf. " +
                                  "The story in large part reflects a profound crisis in Hesse's spiritual world during the 1920s.",
                    Genre = Genre.Autobiographical,
                    CreatedUtc = seedingDateTime,
                    ModifiedUtc = seedingDateTime,
                    AuthorId = author5.Id
                },
                new Book
                {
                    Id = 7,
                    Title = "The Monk Who Sold His Ferrari ",
                    Description = "The Monk Who Sold His Ferrari is a self-help book by Robin Sharma, a writer and motivational speaker. " +
                                  "The book is a business fable derived from Sharma's personal experiences after leaving his " +
                                  "career as a litigation lawyer at the age of 25.",
                    Genre = Genre.Autobiographical,
                    CreatedUtc = seedingDateTime,
                    ModifiedUtc = seedingDateTime,
                    AuthorId = author6.Id
                }
                );

        }
    }
}
