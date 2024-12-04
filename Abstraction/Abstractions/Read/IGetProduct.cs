using Domen.DTOs._read_DTOs;
using Domen.DTOs.QueryDTO;

namespace Abstraction.Abstractions.Read
{
    public interface IGetProduct
    {
        Task<IEnumerable<GetProductDto>> GetProductsAsync(double? productPrice,
                                                          CancellationToken cancellationToken);
        Task<GetProductDetailedDto> GetProductAsync(Guid productBarcode,
                                                     CancellationToken cancellationToken);
    }
}
