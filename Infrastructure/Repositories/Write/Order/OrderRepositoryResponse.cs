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
    public class OrderRepositoryResponse : IOrderRepositoryResponse
    {
        private readonly DbContextwrite _DbContext;

        public OrderRepositoryResponse(DbContextwrite DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task<OrderWriteModel> ResponseOrder(Guid order_Code)
        {
            OrderWriteModel order;
            order = await _DbContext.Orders.SingleOrDefaultAsync(x => x.Code == order_Code);
            return order;
        }
    }
}
