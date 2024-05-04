
using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using AutoMapper;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Customer
{
    public class CustomerDeleteHandler : IRequestHandler<CustomerRequestDeleteDTO, CustomerResponseDeleteDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerRequestDeleteDTO> _validator;
        private readonly ICustomerRemoveRepository _repositoryRemove;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDeleteHandler(
            IMapper mapper,
            IValidator<CustomerRequestDeleteDTO> validator,
            ICustomerRemoveRepository repositoryRemove,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryRemove = repositoryRemove;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResponseDeleteDTO> Handle(
            CustomerRequestDeleteDTO request,
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

            CustomerWriteModel customerFromdb=new();

            try
            {
                //Begin transaction
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                //Deleting from database
                customerFromdb = await _repositoryRemove.RemoveCustomerAsync(request.PIN, cancellationToken);

                //Saving changes
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }

            //Mapping Entity to DTO
            var response = _mapper.Map<CustomerResponseDeleteDTO>(customerFromdb);

            //Response
            return response;
        }
    }
}
