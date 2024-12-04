using Buisness.DTOs.Command.Order;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.DTOs.Write.Order;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Write.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostOrderRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateOrderRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }
    }
}
