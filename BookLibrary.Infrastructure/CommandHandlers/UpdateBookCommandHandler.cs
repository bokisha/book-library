using BookLibrary.DAL.InMemory;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.CommandRequests
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IBookLibraryDbContext _context;
        public UpdateBookCommandHandler(IBookLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = _context.Books.Where(a => a.Id == command.Id).FirstOrDefault();
            if (book == null)
            {
                return default;
            }
            else
            {
                book.Title = command.Title;
                book.Description = command.Description;
                book.Genre = command.Genre.Value;
                book.AuthorId = command.AuthorId.Value;
                book.Description = command.Description;
                book.ModifiedUtc = DateTime.UtcNow;
                await _context.SaveChanges();
                return book.Id;
            }
        }
    }
}
