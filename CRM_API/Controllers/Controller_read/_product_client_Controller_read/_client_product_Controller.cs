using Abstraction.Abstractions._read_Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Controller_read._product_client_Controller_read
{
    [Route("api/[controller]")]
    [ApiController]
    public class _client_product_Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        IProductReadRepository product_Repository_get;

        public _client_product_Controller(IMediator mediator, IProductReadRepository product_Repository_get)
        {
            _mediator = mediator;
            this.product_Repository_get = product_Repository_get;
        }

        [HttpGet("_all_products")]
        public async Task<IActionResult> GetAllProducts([FromQuery] double? product_Price)
        {
            var respons = await product_Repository_get.GetProducts(product_Price);
           
            return Ok(respons);
        }

        [HttpGet("Barcode")]
        public async Task<IActionResult> GetForCustomer(Guid product_Barcode)
        {
            var respons = await product_Repository_get.GetProduct(product_Barcode);
            return Ok(respons);
        }
    }
}
