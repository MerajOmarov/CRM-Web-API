using Abstraction.Abstractions.Write.Product;
using Azure;
using Domen.DTOs.Write.Product;
using MediatR;

namespace Buisness.Handlers.ProductHandler
{
    public class ProductDeleteHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IDeleteProduct _deleteProduct;

        public ProductDeleteHandler(IDeleteProduct deleteProduct)
        {
            _deleteProduct = deleteProduct;
        }

        public async Task<DeleteProductResponse> Handle(
            DeleteProductRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _deleteProduct.DeleteProductAsync(request, cancellationToken);

            return response;
        }
    }
}
