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
        private readonly ICOPReadRepository _customerOrderProductRepository;

        public _company_cop_Controller(ICOPReadRepository customerOrderProductRepository)
        {
            _customerOrderProductRepository = customerOrderProductRepository;
        }

        [HttpGet("Code")]
        public async Task<IActionResult> GetForOrder(Guid guidOfOrder, CancellationToken cancellation)
        {
            var respons = await _customerOrderProductRepository.ReadCOP(guidOfOrder);
            return Ok(respons);
        }

        [HttpGet("PIN")]
        public async Task<IActionResult> GetForCustomer(Guid guidOfCustomer, CancellationToken cancellation)
        {
            var respons = await _customerOrderProductRepository.ReadCOPs(guidOfCustomer);
            return Ok(respons);
        }
    }
}
