using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure.CommandRequests;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookLibraryDbContext _context;
        public CreateBookCommandHandler(IBookLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var createdDateTime = DateTime.UtcNow;
            var book = new Book();
            book.CreatedUtc = createdDateTime;
            book.ModifiedUtc = createdDateTime;
            book.Title = command.Title;
            book.Description = command.Description;
            book.Genre = command.Genre;
            book.AuthorId = command.AuthorId;
            _context.Books.Add(book);
            await _context.SaveChanges();
            return book.Id;
        }
    }
}
