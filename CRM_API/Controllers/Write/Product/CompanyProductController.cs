using Buisness.DTOs.Command.Product;
using Buisness.DTOs.CommandDTOs.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Write.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequestPostDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductRequestUpdateDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ProductRequestDeleteDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }
    }
}
