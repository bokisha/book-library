using BookLibrary.Core.Entities;
using BookLibrary.Core.Models;
using BookLibrary.Infrastructure.CommandRequests;
using BookLibrary.Infrastructure.Queries;
using BookLibrary.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Book> books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books.Select(book => _bookModelConverter.ConvertToModel(book)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Book book = await _mediator.Send(new GetBookByIdQuery { Id = id });
            if (book == null)
            {
                return NotFound();
            }
            return Ok(_bookModelConverter.ConvertToModel(book));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await _mediator.Send(new GetBookByIdQuery { Id = id });
            if (book == null)
            {
                return NotFound();
            }
            return Ok(await _mediator.Send(new DeleteBookByIdCommand { Id = id }));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            Book book = await _mediator.Send(new GetBookByIdQuery { Id = id });
            if (book == null)
            {
                return NotFound();
            }

            return Ok(await _mediator.Send(command));
        }
    }
}
