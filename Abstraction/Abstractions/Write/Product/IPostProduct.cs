using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IPostProduct
    {
        Task<ProductWriteModel> PostProductAsync(ProductWriteModel model,
                              CancellationToken cancellationToken);
    }
}
