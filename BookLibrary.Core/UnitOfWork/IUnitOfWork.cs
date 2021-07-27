using System.Threading.Tasks;
using BookLibrary.Core.Repositories;

namespace BookLibrary.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        Task CompleteAsync();
    }
}
