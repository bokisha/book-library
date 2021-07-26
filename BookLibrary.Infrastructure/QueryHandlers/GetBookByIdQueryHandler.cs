using BookLibrary.Core.Entities;
using MediatR;
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
            var product = await _context.Books.FindAsync(query.Id);
            if (product == null) return null;
            return product;
        }
    }
}
