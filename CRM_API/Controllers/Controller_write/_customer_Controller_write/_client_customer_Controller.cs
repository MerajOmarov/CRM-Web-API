
using Buisness.ActionFilters.CommandActionFilter.CustomerActionFilters;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.Command.Order;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.Models.CommandModels;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Controller_write._customer_Controller_write
{

    [Route("api/[controller]")]
    [ApiController]

    public class _client_customer_Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        public _client_customer_Controller(IMediator mediator)
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
