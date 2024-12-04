using Domen.DTOs.Write.Product;
using Domen.Models.CommandModels;

namespace Abstraction.Abstractions.Write.Product
{
    public interface IDeleteProduct
    {
        Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request, CancellationToken cancellationToken);
    }
}
