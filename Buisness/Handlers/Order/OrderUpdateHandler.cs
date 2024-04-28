
using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
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
        private readonly IUnitOfWork _unitOfWork_Repository;

        public OrderUpdateHandler(IMapper mapper, IValidator<OrderRequestUpdateDTO> validator,
                                  IOrderUpdateRepository repositoryUpdate,
                                  IOrderResponseRepository repositoryOrderResponse,
                                  IProductResponseRepository repositoryProductResponse,
                                  ICustomerResponseRepository customer_Repository_respons,
                                  IUnitOfWork unitOfWork_Repository)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryUpdate = repositoryUpdate;
            _repositoryOrderResponse = repositoryOrderResponse;
            _repositoryProductResponse = repositoryProductResponse;
            _repositoryCustomerResponse = customer_Repository_respons;
            _unitOfWork_Repository = unitOfWork_Repository;
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

            // Updating to database
            await _repositoryUpdate.UpdateOrder(request.oldCode, request.newCode, request.newDeedline);

            //Saving changes
            await _unitOfWork_Repository.Save(cancellationToken);

            //Result
            var orderFromdb = await _repositoryOrderResponse.ResponseOrder(request.newCode);

            // Mapping Entity to DTO
            var response = _mapper.Map<OrderResponseUpdateDTO>(orderFromdb);

            var customer = await _repositoryCustomerResponse.ResponseCustomer(orderFromdb.CustomerPIN);

            var product = await _repositoryProductResponse.ResponseProduct(orderFromdb.ProductBarcode);

            response.CustomerName = customer.Name;

            response.ProductName = product.Name;

            //Response
            return response;
        }
    }
}
