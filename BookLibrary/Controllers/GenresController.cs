using BookLibrary.Core;
using BookLibrary.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {  
            return Ok(EnumHelper.GetSelectItems(typeof(Genre)));
        }
    }
}
