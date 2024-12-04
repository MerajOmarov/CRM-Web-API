using Abstraction.Abstractions.Write.Order;
using Domen.DTOs.Write.Order;
using MediatR;

namespace Buisness.Handlers.Order
{
    public class OrderDeleteHandler : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly IDeleteOrder _deleteOrder;

        public OrderDeleteHandler(IDeleteOrder deleteOrder)
        {
            _deleteOrder = deleteOrder;
        }

        public async Task<DeleteOrderResponse> Handle(
            DeleteOrderRequest request,
            CancellationToken cancellationToken)
        {
            var orderFromdb = await _deleteOrder.DeleteOrderAsync(request, cancellationToken);

            return orderFromdb ;
        }
    }
}
