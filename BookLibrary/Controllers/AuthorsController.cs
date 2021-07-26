﻿using BookLibrary.Core.Entities;
using BookLibrary.Core.Models;
using BookLibrary.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEntityModelConverter<Author, SelectItemByIdModel> _authorModelConverter;

        public AuthorsController(IMediator mediator, IEntityModelConverter<Author, SelectItemByIdModel> authorModelConverter)
        {
            _mediator = mediator;
            _authorModelConverter = authorModelConverter;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Author> authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors.Select(author => _authorModelConverter.ConvertToModel(author)));
        }
    }
}