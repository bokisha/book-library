using BookLibrary.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace BookLibrary.Infrastructure.Queries
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<Author>>
    {       
    }
}
