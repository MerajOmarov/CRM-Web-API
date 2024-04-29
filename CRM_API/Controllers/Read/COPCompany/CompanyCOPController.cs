using Abstraction.Abstractions.Read;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Read.COPCompany
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyCOPController : ControllerBase
    {
        private readonly ICOPReadRepository _cop;

        public CompanyCOPController(ICOPReadRepository cop)
        {
            _cop = cop;
        }

        [HttpGet("Code")]
        public async Task<IActionResult> GetForOrder(Guid guidOfOrder, CancellationToken cancellation)
        {
            var respons = await _cop.GetCOPAsync(guidOfOrder, cancellation);

            return Ok(respons);
        }

        [HttpGet("PIN")]
        public async Task<IActionResult> GetForCustomer(Guid guidOfCustomer, CancellationToken cancellation)
        {
            var respons = await _cop.GetCOPsAsync(guidOfCustomer, cancellation);

            return Ok(respons);
        }
    }
}
