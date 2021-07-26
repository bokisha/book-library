using MediatR;

namespace BookLibrary.Infrastructure.CommandRequests
{
    public partial class DeleteBookByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
