using Abstraction.Abstractions.Write.Product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class ProductRemoveRepository : IProductRemoveRepository
    {
        private readonly WriteDbContext _dbContext;
        private readonly IProductResponseRepository _response;

        public ProductRemoveRepository(WriteDbContext dbContext, IProductResponseRepository response)
        {
            _dbContext = dbContext;
            _response = response;
        }

        public async Task<ProductWriteModel> RemoveProductAsync(Guid ProductBarcode,
                                                                CancellationToken cancellationToken)
        {
            ProductWriteModel product = await _response.ResponseProductAsync(ProductBarcode, cancellationToken);

            _dbContext.Products.Remove(product);

            return product;
        }
    }
}
