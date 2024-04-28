using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<OrderWriteModel> RemoveOrder(Guid orderCode)
        {
            OrderWriteModel order = await _response.ResponseOrder(orderCode);

            _dbContext.Orders.Remove(order);

            return order;
        }
    }
}
