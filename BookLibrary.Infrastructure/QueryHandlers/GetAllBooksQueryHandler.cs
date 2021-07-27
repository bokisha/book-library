using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.UnitOfWork;

namespace BookLibrary.Infrastructure.QueryHandlers
{
    public class GetAllBooksQueryQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBooksQueryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var booksList = await _unitOfWork.Books.GetAll();
            if (booksList == null)
            {
                return new List<Book>();
            }
            return booksList;
        }
    }
}
