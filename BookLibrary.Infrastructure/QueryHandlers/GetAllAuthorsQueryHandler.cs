using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BookLibrary.Core.UnitOfWork;

namespace BookLibrary.Infrastructure.QueryHandlers
{
    public class GetAllAuthorsQueryQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllAuthorsQueryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authorsList = await _unitOfWork.Authors.GetAll();
            if (authorsList == null)
            {
                return new List<Author>();
            }
            return authorsList;
        }
    }
}
