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
    public class OrderRepositoryRemove : IOrderRepositoryRemove
    {
        private readonly DbContextwrite _DbContext;
        private readonly IOrderRepositoryResponse _Response;

        public OrderRepositoryRemove(DbContextwrite dbContext, IOrderRepositoryResponse response)
        {
            _DbContext = dbContext;
            _Response = response;
        }

        public async Task<OrderWriteModel> RemoveOrder(Guid orderCode)
        {
            OrderWriteModel order = await _Response.ResponseOrder(orderCode);
            _DbContext.Orders.Remove(order);
            return order;
        }
    }
}
