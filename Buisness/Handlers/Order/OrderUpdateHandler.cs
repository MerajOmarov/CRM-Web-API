
using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using Abstraction.Abstractions.Write.Order;
using Abstraction.Abstractions.Write.Product;
using AutoMapper;
using Buisness.DTOs.Command.Order;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Order
{
    public class OrderUpdateHandler : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUpdateOrder _updateOrder;

        public OrderUpdateHandler(IMapper mapper, IUpdateOrder updateOrder)
        {
            _mapper = mapper;
            _updateOrder = updateOrder;
        }

        public async Task<UpdateOrderResponse> Handle(
            UpdateOrderRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _updateOrder.UpdateOrderAsync(request,cancellationToken);

            return _mapper.Map<UpdateOrderResponse>(request);
        }
    }
}
