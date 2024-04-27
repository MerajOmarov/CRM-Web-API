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
    public  class OrderRepositoryPost:IOrderRepositoryPost
    {
        private readonly WriteDbContext _DbContext;

        public OrderRepositoryPost(WriteDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task PostOrder(OrderWriteModel order)
        {
            var response = await _DbContext.Orders.SingleOrDefaultAsync(x => x.Code == order.Code);
            if(response != null)
            {
                throw new Exception("ResponsOrder Error: The order with this guid have already exists in database, use different guid");
            }
            await _DbContext.Orders.AddAsync(order);
        }
    }
}
