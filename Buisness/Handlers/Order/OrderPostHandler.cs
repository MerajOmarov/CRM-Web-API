
using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using AutoMapper;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Order;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Order
{
    public class OrderPostHandler : IRequestHandler<OrderPostDTOrequest, OrderPostDTOresponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<OrderPostDTOrequest> _validator;
        private readonly IOrderRepositoryPost _repositoryPost;
        private readonly ICustomerRepositoryResponse _repositoryCustomerResponse;
        private readonly IProductRepositoryResponse _repositoryProductResponse;
        private readonly IOrderRepositoryResponse _repositoryOrderResponse;
        private readonly IUnitOfWork _unitOfWork;

        public OrderPostHandler(
            IMapper mapper,
            IValidator<OrderPostDTOrequest> validator,
            IOrderRepositoryPost order_Repository_post,
            ICustomerRepositoryResponse customer_Repository_respons,
            IProductRepositoryResponse product_Repository_respons,
            IOrderRepositoryResponse order_Repository_respons,
            IUnitOfWork unitOfWork_Respository)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryPost = order_Repository_post;
            _repositoryCustomerResponse = customer_Repository_respons;
            _repositoryProductResponse = product_Repository_respons;
            _repositoryOrderResponse = order_Repository_respons;
            _unitOfWork = unitOfWork_Respository;
        }

        public async Task<OrderPostDTOresponse> Handle(
            OrderPostDTOrequest request,
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

            //Mapping DTO to Entity
            var orderTodb = _mapper.Map<OrderWriteModel>(request);

            var customerToOrder = await _repositoryCustomerResponse.ResponseCustomer(request.CustomerPIN);

            var productToOrder = await _repositoryProductResponse.ResponseProduct(request.ProductBarcode);

            orderTodb.CustomerID = customerToOrder.ID;

            orderTodb.productID = productToOrder.ID;

            // Adding to database
            await _repositoryPost.PostOrder(orderTodb);

            //Saving changes
            await _unitOfWork.Save(cancellationToken);

            //Result
            var orderFromdb = await _repositoryOrderResponse.ResponseOrder(orderTodb.Code);

            // Mapping Entity to DTO
            var response = _mapper.Map<OrderPostDTOresponse>(orderFromdb);

            response.CustomerName = customerToOrder.Name;

            response.ProductName = productToOrder.Name;

            //Respons
            return response;
        }
    }
}
