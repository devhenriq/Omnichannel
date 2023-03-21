using Microsoft.AspNetCore.Mvc;
using People.Domain.Aggregates;

namespace Person.Api.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personRepository.GetAll());
        }
    }
}