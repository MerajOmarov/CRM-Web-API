using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Domen.Models.CommandModels;
using Infrastructure.DataContexts.CommandDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public class OrderResponseRepository : IOrderResponseRepository
    {
        private readonly WriteDbContext _dbContext;

        public OrderResponseRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderWriteModel> ResponseOrder(Guid orderCode)
        {
            var order = await _dbContext.Orders.SingleOrDefaultAsync(x => x.Code == orderCode);

            return order;
        }
    }
}
