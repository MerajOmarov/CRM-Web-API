using Buisness.DTOs.Command.Order;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Controller_write._order_Controller_write
{
    [Route("api/[controller]")]
    [ApiController]
    public class _client_order_Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public _client_order_Controller(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderPostDTOrequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);
            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderUpdateDTOrequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);
            return Ok(respons);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] OrderDeleteDTOrequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);
            return Ok(respons);
        }
    }
}
