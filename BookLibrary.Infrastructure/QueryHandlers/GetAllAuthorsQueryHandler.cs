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
    public class GetAllAuthorsQueryQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IBookLibraryDbContext _context;
        public GetAllAuthorsQueryQueryHandler(IBookLibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authorsList = await _context.Authors
                .ToListAsync();
            if (authorsList == null)
            {
                return null;
            }
            return authorsList.AsReadOnly();
        }
    }
}
