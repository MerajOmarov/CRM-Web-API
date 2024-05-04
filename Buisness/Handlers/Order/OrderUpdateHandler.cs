
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
    public class OrderUpdateHandler : IRequestHandler<OrderRequestUpdateDTO, OrderResponseUpdateDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<OrderRequestUpdateDTO> _validator;
        private readonly IOrderUpdateRepository _repositoryUpdate;
        private readonly IOrderResponseRepository _repositoryOrderResponse;
        private readonly IProductResponseRepository _repositoryProductResponse;
        private readonly ICustomerResponseRepository _repositoryCustomerResponse;
        private readonly IUnitOfWork _unitOfWork;

        public OrderUpdateHandler(IMapper mapper, IValidator<OrderRequestUpdateDTO> validator,
                                  IOrderUpdateRepository repositoryUpdate,
                                  IOrderResponseRepository repositoryOrderResponse,
                                  IProductResponseRepository repositoryProductResponse,
                                  ICustomerResponseRepository repositoryCustomerResponse,
                                  IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryUpdate = repositoryUpdate;
            _repositoryOrderResponse = repositoryOrderResponse;
            _repositoryProductResponse = repositoryProductResponse;
            _repositoryCustomerResponse = repositoryCustomerResponse;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderResponseUpdateDTO> Handle(
            OrderRequestUpdateDTO request,
            CancellationToken cancellationToken)
        {
            //Validation
            var result = await _validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Begin Transaction
           
            // Updating to database
            await _repositoryUpdate.UpdateOrderAsync(request.oldCode,
                                                     request.newCode,
                                                     request.newDeedline,
                                                     cancellationToken);

            //Saving changes
            await _unitOfWork.SaveAsync(cancellationToken);

            //Result
            var orderFromdb = await _repositoryOrderResponse.ResponseOrderAsync(request.newCode,
                                                                                cancellationToken);

            // Mapping Entity to DTO
            var response = _mapper.Map<OrderResponseUpdateDTO>(orderFromdb);

            var customer = await _repositoryCustomerResponse.ResponseCustomerAsync(orderFromdb.CustomerPIN,
                                                                                   cancellationToken);

            var product = await _repositoryProductResponse.ResponseProductAsync(orderFromdb.ProductBarcode,
                                                                                cancellationToken);

            response.CustomerName = customer.Name;

            response.ProductName = product.Name;

            //Response
            return response;
        }
    }
}
