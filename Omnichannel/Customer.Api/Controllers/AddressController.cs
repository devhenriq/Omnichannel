using Customers.Domain.Aggregates.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Api.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromRoute] string zipCode)
        {
            return Ok(await _addressRepository.GetAddressAsync(zipCode));
        }

    }
}
