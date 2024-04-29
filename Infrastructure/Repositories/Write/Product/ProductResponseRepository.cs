using Abstraction.Abstractions.Write.Product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class ProductResponseRepository : IProductResponseRepository
    {
        private readonly WriteDbContext _dbContext;

        public ProductResponseRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductWriteModel> ResponseProductAsync(Guid productBarcode,CancellationToken cancellationToken)
        {
            ProductWriteModel product= await _dbContext.Products.SingleOrDefaultAsync(x => x.Barcode == productBarcode);
            return product;
        }
    }
}
