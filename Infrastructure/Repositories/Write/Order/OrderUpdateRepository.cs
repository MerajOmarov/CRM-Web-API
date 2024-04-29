using Abstraction.Abstractions.Write.Order;
using Domen.Models.CommandModels;

namespace Infrastructure.Repositories.CommandRepositories.OrderRepository
{
    public  class OrderUpdateRepository:IOrderUpdateRepository
    {

        private readonly IOrderResponseRepository _response;

        public OrderUpdateRepository(IOrderResponseRepository response)
        {
            _response = response;
        }

        public async Task UpdateOrderAsync(Guid oldOrderCode,
                                           Guid newOrderCode,
                                           DateTime newOrderDeedline,
                                           CancellationToken cancellationToken)
        {
            OrderWriteModel order = await _response.ResponseOrderAsync(oldOrderCode, cancellationToken);

            order.Code = newOrderCode;

            order.Deedline = newOrderDeedline;
        }
    }
}
