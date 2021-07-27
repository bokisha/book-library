using System;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.Entities;
using BookLibrary.Core.UnitOfWork;
using BookLibrary.Infrastructure.CommandRequests;
using MediatR;

namespace BookLibrary.Infrastructure.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            Book book = await _unitOfWork.Books.GetById(command.Id.Value);
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
                await _unitOfWork.Books.Update(book);
                await _unitOfWork.CompleteAsync();
                return book.Id;
            }
        }
    }
}
