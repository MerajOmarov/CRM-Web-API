using Abstraction;
using Abstraction.Abstractions.Write.Order;
using Domen.DTOs.Write.Order;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public class DeleteOrder : IDeleteOrder
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork  _unitOfWork;

        public DeleteOrder(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteOrderResponse> DeleteOrderAsync(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                var order = await _dbContext.Orders.SingleOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

                _dbContext.Orders.Remove(order!);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return new DeleteOrderResponse() { Code = order!.Code };
            }
            catch (Exception)
            {
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                throw new Exception("Failed Process"); 
            }
        }
    }
}
