using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.UnitOfWork;
using BookLibrary.Infrastructure.CommandRequests;
using MediatR;

namespace BookLibrary.Infrastructure.CommandHandlers
{
    public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Books.GetById(command.Id);
            if (product == null) return default;
            await _unitOfWork.Books.Delete(command.Id);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }
    }
}
