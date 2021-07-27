using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BookLibrary.Api.Models;
using BookLibrary.Core.Entities;
using BookLibrary.Infrastructure.CommandRequests;
using BookLibrary.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Api.Controllers

{
    [Produces("application/json")]
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
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Create(CreateBookCommandModel commandModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _mediator.Send(commandModel));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Book>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Book> books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books.Select(book => _bookModelConverter.ConvertToModel(book)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Update(int id, UpdateBookCommand command)
        {
            if (!ModelState.IsValid || id != command.Id)
            {
                return BadRequest(ModelState);
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
