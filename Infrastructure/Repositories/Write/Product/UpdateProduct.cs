using Abstraction;
using Abstraction.Abstractions.Write.Product;
using Domen.DTOs.Write.Product;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.ProductRepository
{
    public class UpdateProduct : IUpdateProduct
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork  _unitOfWork;

        public UpdateProduct(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductWriteModel> UpdateProductAsync(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

                product!.Price = request.NewPrice;

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
