using Abstraction.Abstractions._read_Abstractions;
using Buisness.DTOs.Command.Order;
using Domen.DTOs.QueryDTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Presentation.Controllers.Controller_read._cop_Controller_read
{
    [Route("api/[controller]")]
    [ApiController]
    public class _company_cop_Controller : ControllerBase
    {
        private readonly IRepository_cop_get _customerOrderProductRepository;

        public _company_cop_Controller(IRepository_cop_get customerOrderProductRepository)
        {
            _customerOrderProductRepository = customerOrderProductRepository;
        }

        [HttpGet("_order_Code")]
        public async Task<IActionResult> GetForOrder(Guid guidOfOrder, CancellationToken cancellation)
        {
            var respons = await _customerOrderProductRepository._cop_Method_get(guidOfOrder);
            return Ok(respons);
        }

        [HttpGet("_customer_PIN")]
        public async Task<IActionResult> GetForCustomer(Guid guidOfCustomer, CancellationToken cancellation)
        {
            var respons = await _customerOrderProductRepository._all_cops_Method_get(guidOfCustomer);
            return Ok(respons);
        }
    }
}
