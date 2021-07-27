using BookLibrary.Core.Entities;
using BookLibrary.Core.Repositories;

namespace BookLibrary.DAL.InMemory.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {        
        public AuthorRepository(BookLibraryDbContext dataContext) : base(dataContext)
        {
        }
    }
}
