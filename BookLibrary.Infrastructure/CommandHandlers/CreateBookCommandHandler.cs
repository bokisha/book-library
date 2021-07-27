using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure.CommandRequests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.UnitOfWork;

namespace BookLibrary.Infrastructure.CommandHandlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommandModel, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateBookCommandModel commandModel, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = commandModel.Title,
                Description = commandModel.Description,
                Genre = commandModel.Genre.Value,
                AuthorId = commandModel.AuthorId.Value
            };
            await _unitOfWork.Books.Add(book);
            await _unitOfWork.CompleteAsync();
            return book.Id;
        }
    }
}
