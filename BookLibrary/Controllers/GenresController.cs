using BookLibrary.Core;
using BookLibrary.Core.Enums;
using BookLibrary.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookLibrary.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SelectItemByIdModel>),StatusCodes.Status200OK)]
        public IActionResult Get()
        {  
            return Ok(EnumHelper.GetSelectItems(typeof(Genre)));
        }
    }
}
