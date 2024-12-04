using Abstraction;
using Abstraction.Abstractions.Write.Product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class PostProduct : IPostProduct
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public PostProduct(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductWriteModel> PostProductAsync(ProductWriteModel product, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                var response = await _dbContext.Products.SingleOrDefaultAsync(x => x.Barcode == product.Barcode);

                await _dbContext.Products.AddAsync(product, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return product;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }
        }
    }
}
