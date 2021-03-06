using BookLibrary.Core.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Infrastructure.CommandRequests
{
    public class CreateBookCommandModel : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Genre? Genre { get; set; }
        [Required]
        public int? AuthorId { get; set; }
    }
}
