using Buisness.DTOs.Command.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Write.Customer
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequestPostDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpPut]
        //[Authorize]
        //[ServiceFilter(typeof(postCustomerActionFilter))]
        public async Task<IActionResult> Put([FromBody] CustomerRequestUpdateDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpDelete]
        //[Authorize]
        //[ServiceFilter(typeof(postCustomerActionFilter))]
        public async Task<IActionResult> Delete([FromBody] CustomerRequestDeleteDTO request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }




    }
}
