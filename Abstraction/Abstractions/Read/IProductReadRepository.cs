using Domen.DTOs._read_DTOs;
using Domen.DTOs.QueryDTO;

namespace Abstraction.Abstractions.Read
{
    public interface IProductReadRepository
    {
        Task<IEnumerable<ProductGetDTO>> GetProductsAsync(double? productPrice,
                                                          CancellationToken cancellationToken);
        Task<ProductDetailedReadDTO> GetProductAsync(Guid productBarcode,
                                                     CancellationToken cancellationToken);
    }
}
