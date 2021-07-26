using BookLibrary.Core.Enums;
using MediatR;

namespace BookLibrary.Infrastructure.CommandRequests
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
    }
}
