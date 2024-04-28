using Domen.DTOs._read_DTOs;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.DTOs.QueryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Abstractions._read_Abstractions
{
    public interface IProductReadRepository
    {
        Task<IEnumerable<ProductGetDTO>> GetProductsAsync(double? productPrice, CancellationToken cancellationToken);
        Task<ProductDetailedReadDTO> GetProductAsync(Guid productBarcode, CancellationToken cancellationToken);
    }
}
