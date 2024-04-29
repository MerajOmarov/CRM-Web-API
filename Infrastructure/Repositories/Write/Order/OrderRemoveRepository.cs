using Abstraction.Abstractions.Write.Order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public class OrderRemoveRepository : IOrderRemoveRepository
    {
        private readonly WriteDbContext _dbContext;
        private readonly IOrderResponseRepository _response;

        public OrderRemoveRepository(WriteDbContext dbContext, IOrderResponseRepository response)
        {
            _dbContext = dbContext;
            _response = response;
        }

        public async Task<OrderWriteModel> RemoveOrderAsync(Guid orderCode, CancellationToken cancellationToken)
        {
            OrderWriteModel order = await _response.ResponseOrderAsync(orderCode,cancellationToken);

            _dbContext.Orders.Remove(order);

            return order;
        }
    }
}
