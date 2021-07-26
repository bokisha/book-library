using BookLibrary.Core.Enums;
using MediatR;

namespace BookLibrary.Infrastructure.CommandRequests
{
    public partial class UpdateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
    }
}
