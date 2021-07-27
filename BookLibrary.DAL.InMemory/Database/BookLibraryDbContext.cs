using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DAL.InMemory.Database
{
    public class BookLibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookLibraryDbContext(DbContextOptions options)
          : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var currentDateTime = DateTime.UtcNow;
                ((IEntity)entityEntry.Entity).ModifiedUtc = currentDateTime;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IEntity)entityEntry.Entity).CreatedUtc = currentDateTime;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
