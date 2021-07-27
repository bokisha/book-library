using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure.CommandRequests;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.UnitOfWork;

namespace BookLibrary.Infrastructure.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var createdDateTime = DateTime.UtcNow;
            var book = new Book
            {
                CreatedUtc = createdDateTime,
                ModifiedUtc = createdDateTime,
                Title = command.Title,
                Description = command.Description,
                Genre = command.Genre.Value,
                AuthorId = command.AuthorId.Value
            };
            await _unitOfWork.Books.Add(book);
            await _unitOfWork.CompleteAsync();
            return book.Id;
        }
    }
}
