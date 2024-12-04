using Abstraction;
using Abstraction.Abstractions.Write.Order;
using Buisness.DTOs.Command.Order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public  class UpdateOrder:IUpdateOrder
    {
        private readonly WriteDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrder(WriteDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderWriteModel> UpdateOrderAsync(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                var order = await _dbContext.Orders.SingleOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

                order!.Deedline = request.newDeedline;
                order.Code = request.newCode;

                await _dbContext.SaveChangesAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                return order!;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }
        }
    }
}
