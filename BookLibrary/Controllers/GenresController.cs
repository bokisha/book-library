using BookLibrary.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookLibrary.Enums;
using BookLibrary.Models;

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
