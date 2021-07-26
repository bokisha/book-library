using BookLibrary.Core.Entities;
using BookLibrary.Core.Models;
using BookLibrary.Infrastructure.CommandRequests;
using BookLibrary.Infrastructure.Queries;
using BookLibrary.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEntityModelConverter<Book, BookModel> _bookModelConverter;

        public BooksController(IMediator mediator, IEntityModelConverter<Book, BookModel> bookModelConverter)
        {
            _mediator = mediator;
            _bookModelConverter = bookModelConverter;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Book> books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books.Select(book => _bookModelConverter.ConvertToModel(book)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetBookByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteBookByIdCommand { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}
