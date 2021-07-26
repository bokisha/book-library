using BookLibrary.Core.Entities;
using MediatR;

namespace BookLibrary.Infrastructure.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
    }
}
