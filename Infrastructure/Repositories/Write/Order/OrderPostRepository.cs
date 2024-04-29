using Abstraction.Abstractions.Write.Order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public  class OrderPostRepository:IOrderPostRepository
    {
        private readonly WriteDbContext _dbContext;
        public OrderPostRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostOrderAsync(OrderWriteModel order, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Orders.SingleOrDefaultAsync(x => x.Code == order.Code);

            if(response != null)
                throw new Exception("ResponsOrder Error: The order with this guid have already exists in database, use different guid");

            await _dbContext.Orders.AddAsync(order);
        }
    }
}
