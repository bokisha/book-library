using BookLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure
{
    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Author> Authos { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookLibraryDbContext(DbContextOptions options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
