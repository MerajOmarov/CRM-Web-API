using Buisness.DTOs.CommandDTOs.Product;
using Domen.DTOs.Write.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Write.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostProductRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }
    }
}
