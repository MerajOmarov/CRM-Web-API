using Abstraction.Abstractions.Read;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.Read.COPCompany
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProductController : ControllerBase
    {
        IProductReadRepository _product;

        public ClientProductController(IProductReadRepository product)
        {
            _product = product;
        }

        [HttpGet("allproducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] double? productPrice, CancellationToken cancellationToken)
        {
            var respons = await _product.GetProductsAsync(productPrice, cancellationToken);
    
            return Ok(respons);
        }

        [HttpGet("Barcode")]
        public async Task<IActionResult> GetForCustomer(Guid productBarcode, CancellationToken cancellationToken)
        {
            var respons = await _product.GetProductAsync(productBarcode, cancellationToken);

            return Ok(respons);
        }
    }
}
