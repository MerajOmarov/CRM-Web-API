
using Abstraction;
using Abstraction.Abstractions.Write.Order;
using AutoMapper;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Order
{
    public class OrderDeleteHandler : IRequestHandler<OrderRequestDeleteDTO, OrderResponseDeleteDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<OrderRequestDeleteDTO> _validator;
        private readonly IOrderRemoveRepository _repositoryRemove;
        private readonly IUnitOfWork _unitOfWork;

        public OrderDeleteHandler(
            IMapper mapper,
            IValidator<OrderRequestDeleteDTO> validator,
            IOrderRemoveRepository repositoryRemove,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryRemove = repositoryRemove;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderResponseDeleteDTO> Handle(
            OrderRequestDeleteDTO request,
            CancellationToken cancellationToken)
        {

            //Validation
            var validationOfRequest = await _validator.ValidateAsync(request);
            if (!validationOfRequest.IsValid)
            {
                foreach (var error in validationOfRequest.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Deleting from database
            OrderWriteModel orderFromdb = await _repositoryRemove.RemoveOrderAsync(request.Code, cancellationToken);

            //Mapping Entity to DTO
            var response = _mapper.Map<OrderResponseDeleteDTO>(orderFromdb);

            //Saving changes
            await _unitOfWork.SaveAsync(cancellationToken);

            //Response
            return response;
        }
    }
}
