using Abstraction.Abstractions.Write.Order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public class OrderResponseRepository : IOrderResponseRepository
    {
        private readonly WriteDbContext _dbContext;

        public OrderResponseRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderWriteModel> ResponseOrderAsync(Guid orderCode,CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.SingleOrDefaultAsync(x => x.Code == orderCode);

            return order;
        }
    }
}
