using Domen.DTOs.Write.Product;
using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IUpdateProduct
    {
        Task<ProductWriteModel> UpdateProductAsync(UpdateProductRequest request, CancellationToken cancellationToken);
    }
}
