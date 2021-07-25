using BookLibrary.Core.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }

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
}
