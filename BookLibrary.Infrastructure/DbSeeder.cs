using BookLibrary.Core.Entities;
using BookLibrary.Core.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookLibrary.Infrastructure
{
    public static class DbSeeder
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            var seedingDateTime = DateTime.UtcNow;

            var author1 = new Author { Id = 1, FirstName = "First", LastName = "Test", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };
            var author2 = new Author { Id = 2, FirstName = "Second", LastName = "Test", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };
            var author3 = new Author { Id = 3, FirstName = "Third", LastName = "Test", CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime };

            modelBuilder.Entity<Author>().HasData(author1, author2, author3);


            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Test One", Description = "Description one", Genre = Genre.Fantasy, CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime, AuthorId = author1.Id },
                new Book { Id = 2, Title = "Test Two", Description = "Description two", Genre = Genre.Action, CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime, AuthorId = author1.Id },
                new Book { Id = 3, Title = "Test Three", Description = "Description three", Genre = Genre.Biography, CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime, AuthorId = author2.Id },
                new Book { Id = 4, Title = "Test Four", Description = "Description four", Genre = Genre.Comic, CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime, AuthorId = author3.Id },
                new Book { Id = 5, Title = "Test Five", Description = "Description five", Genre = Genre.Mystery, CreatedUtc = seedingDateTime, ModifiedUtc = seedingDateTime, AuthorId = author1.Id }
                );
        }
    }
}
