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
    public  class OrderRepositoryUpdate:IOrderRepositoryUpdate
    {

        private readonly IOrderRepositoryResponse _Response;

        public OrderRepositoryUpdate(IOrderRepositoryResponse response)
        {
            _Response = response;
        }

        public async Task UpdateOrder(Guid OldOrderCode, Guid NewOrderCode, DateTime NewOrderDeedline)
        {
            OrderModelwrite order = await _Response.ResponseOrder(OldOrderCode);
            order.Code = NewOrderCode;
            order.Deedline = NewOrderDeedline;
        }
    }
}
