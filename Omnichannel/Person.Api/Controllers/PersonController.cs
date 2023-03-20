using Microsoft.AspNetCore.Mvc;

namespace Person.Api.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {

        public PersonController()
        {
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}