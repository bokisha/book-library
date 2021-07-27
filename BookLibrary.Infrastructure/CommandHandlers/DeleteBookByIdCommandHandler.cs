using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.DAL.InMemory;
using BookLibrary.Infrastructure.CommandRequests;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Infrastructure.CommandHandlers
{
    public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand, int>
    {
        private readonly IBookLibraryDbContext _context;
        public DeleteBookByIdCommandHandler(IBookLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Books.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (product == null) return default;
            _context.Books.Remove(product);
            await _context.SaveChanges();
            return product.Id;
        }
    }
}
