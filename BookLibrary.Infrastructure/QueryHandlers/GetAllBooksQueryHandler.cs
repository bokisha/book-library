using BookLibrary.Core.Entities;
using BookLibrary.DAL.InMemory;
using BookLibrary.Infrastructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.QueryHandlers
{
    public class GetAllBooksQueryQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookLibraryDbContext _context;
        public GetAllBooksQueryQueryHandler(IBookLibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var booksList = await _context.Books
                .Include(book => book.Author)
                .ToListAsync();
            if (booksList == null)
            {
                return null;
            }
            return booksList.AsReadOnly();
        }
    }
}
