using System;
using System.Threading.Tasks;
using BookLibrary.Core.Repositories;
using BookLibrary.Core.UnitOfWork;
using BookLibrary.DAL.InMemory.Database;
using BookLibrary.DAL.InMemory.Repositories;

namespace BookLibrary.DAL.InMemory.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IBookRepository Books { get; }
        public IAuthorRepository Authors { get; }

        private readonly BookLibraryDbContext _context;

        public UnitOfWork(BookLibraryDbContext context)
        {
            _context = context;

            // I could also instantiate this with built-in IoC, but since Repositories directly uses context(on destroy context is disposed),
            // i've decided to instantiate it manually (UoW is instantiated per request)
            Books = new BookRepository(context);
            Authors = new AuthorRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
