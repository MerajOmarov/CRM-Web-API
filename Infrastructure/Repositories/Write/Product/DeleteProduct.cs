using Abstraction;
using Abstraction.Abstractions.Write.Product;
using Domen.DTOs.Write.Product;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class DeleteProduct : IDeleteProduct
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork  _unitOfWork;

        public DeleteProduct(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductResponse> DeleteProductAsync(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == request.Id);

                if (product == null) new Exception("Product not exists ");

                _dbContext.Products.Remove(product!);

                await _dbContext.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return new DeleteProductResponse() {Barcode = product!.Barcode};
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }
        }
    }
}
