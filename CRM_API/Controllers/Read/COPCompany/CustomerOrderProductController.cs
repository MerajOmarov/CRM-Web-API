using Abstraction.Abstractions.Read;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Read.COPCompany
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrderProductController : ControllerBase
    {
        private readonly IGetCustomerObjectProduct _cop;

        public CustomerOrderProductController(IGetCustomerObjectProduct cop)
        {
            _cop = cop;
        }

        [HttpGet("Code")]
        public async Task<IActionResult> GetForOrder([FromQuery]int id, CancellationToken cancellation)
        {
            var respons = await _cop.GetCOPAsync(id, cancellation);

            return Ok(respons);
        }

        [HttpGet("PIN")]
        public async Task<IActionResult> GetForCustomer([FromQuery] int id, CancellationToken cancellation)
        {
            var respons = await _cop.GetCOPsAsync(id, cancellation);

            return Ok(respons);
        }
    }
}
