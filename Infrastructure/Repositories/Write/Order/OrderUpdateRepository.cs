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
    public  class OrderUpdateRepository:IOrderUpdateRepository
    {

        private readonly IOrderResponseRepository _response;

        public OrderUpdateRepository(IOrderResponseRepository response)
        {
            _response = response;
        }

        public async Task UpdateOrder(Guid oldOrderCode, Guid newOrderCode, DateTime newOrderDeedline)
        {
            OrderWriteModel order = await _response.ResponseOrder(oldOrderCode);

            order.Code = newOrderCode;

            order.Deedline = newOrderDeedline;
        }
    }
}
