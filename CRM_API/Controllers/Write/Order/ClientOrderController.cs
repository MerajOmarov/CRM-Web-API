using Buisness.DTOs.Command.Order;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Write.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderRequestPostDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderRequestUpdateDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] OrderRequestDeleteDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }
    }
}
