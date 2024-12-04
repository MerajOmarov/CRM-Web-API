using Abstraction;
using Abstraction.Abstractions.Write.Order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public  class PostOrder:IPostOrder
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork  _unitOfWork;

        public PostOrder(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderWriteModel> PostOrderAsync(OrderWriteModel order, CancellationToken cancellationToken)
        {

            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                await _dbContext.Orders.AddAsync(order, cancellationToken);

                await _dbContext.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return order;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }
        }
    }
}
