using MediatR;

namespace BookLibrary.Infrastructure.CommandRequests
{
    public class DeleteBookByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
