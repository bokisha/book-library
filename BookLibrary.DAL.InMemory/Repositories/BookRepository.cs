using System.Collections.Generic;
using System.Threading.Tasks;
using BookLibrary.Core.Entities;
using BookLibrary.Core.Repositories;
using BookLibrary.DAL.InMemory.Database;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DAL.InMemory.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookLibraryDbContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IEnumerable<Book>> GetAll()
        {
            return await DbSet.Include(b => b.Author).ToListAsync();
        }

        public override async Task<Book> GetById(int id)
        {
            return await DbSet.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
