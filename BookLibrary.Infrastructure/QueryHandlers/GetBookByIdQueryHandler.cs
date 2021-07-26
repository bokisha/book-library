using BookLibrary.Core.Entities;
using BookLibrary.DAL.InMemory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Queries
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookLibraryDbContext _context;
        public GetBookByIdQueryHandler(IBookLibraryDbContext context)
        {
            _context = context;
        }
        public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _context.Books
                .Include(book => book.Author)
                .Where(b => b.Id == query.Id).FirstOrDefaultAsync();
            if (product == null) return null;
            return product;
        }
    }
}
