using Abstraction.Abstractions.Write.Product;
using Domen.Models.CommandModels;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class ProductUpdateRepository : IProductUpdateRepository
    {
        private readonly IProductResponseRepository _response;

        public ProductUpdateRepository(IProductResponseRepository response)
        {
            _response = response;
        }

        public async Task UpdateProductAsync(Guid oldProductBarcode,
                                             Guid? newProductBarcode,
                                             double? newProductPrice,
                                             CancellationToken cancellationToken)
        {
            ProductWriteModel product = await _response.ResponseProductAsync(oldProductBarcode, cancellationToken);

            if (newProductBarcode.HasValue)
                product.Barcode = newProductBarcode.Value;

            if (newProductPrice.HasValue)
                product.Price = newProductPrice.Value;
        }
    }
}
