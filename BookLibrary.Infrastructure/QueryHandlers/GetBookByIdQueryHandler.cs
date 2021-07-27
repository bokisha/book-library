using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.Entities;
using BookLibrary.Core.UnitOfWork;
using BookLibrary.Infrastructure.Queries;
using MediatR;

namespace BookLibrary.Infrastructure.QueryHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetById(query.Id);
        }
    }
}
