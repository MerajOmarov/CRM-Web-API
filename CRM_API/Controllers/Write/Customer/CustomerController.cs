using Buisness.DTOs.Command.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.DTOs.Write.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Write.Customer
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCustomerRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpPut]
        //[Authorize]
        //[ServiceFilter(typeof(postCustomerActionFilter))]
        public async Task<IActionResult> Put([FromBody] UpdateCustomerRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }

        [HttpDelete]
        //[Authorize]
        //[ServiceFilter(typeof(postCustomerActionFilter))]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerRequest request, CancellationToken cancellation)
        {
            var respons = await _mediator.Send(request, cancellation);

            return Ok(respons);
        }




    }
}
