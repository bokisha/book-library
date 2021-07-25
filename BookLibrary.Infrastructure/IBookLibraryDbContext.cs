using BookLibrary.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure
{
    public interface IBookLibraryDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        Task<int> SaveChanges();
    }
}