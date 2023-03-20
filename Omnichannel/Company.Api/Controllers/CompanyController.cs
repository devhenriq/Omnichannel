using Companies.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace Companies.Api.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_companyRepository.GetAll());
        }
    }
}