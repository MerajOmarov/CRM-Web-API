
using Abstraction;
using Abstraction.Abstractions.Write.Customer;
using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Customer
{
    public class CustomerUpdateHandle : IRequestHandler<CustomerRequestUpdateDTO, CustomerResponseUpdateDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerRequestUpdateDTO> _validator;
        private readonly ICustomerUpdateRepository _repositoryUpdate;
        private readonly ICustomerResponseRepository _repositotyResponse;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerUpdateHandle(
            IMapper mapper,
            IValidator<CustomerRequestUpdateDTO> validator,
            ICustomerUpdateRepository repositoryUpdate,
            ICustomerResponseRepository repositotyResponse,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryUpdate = repositoryUpdate;
            _repositotyResponse = repositotyResponse;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResponseUpdateDTO> Handle(
            CustomerRequestUpdateDTO request,
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

            try
            {
                //Begin Transaction
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted,cancellationToken);

                // Updating to database
                await _repositoryUpdate.UpdateCustomerAsync(request.oldPIN, request.newPIN, cancellationToken);

                //Saving changes
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }

            //Result
            var customerFromdb = await _repositotyResponse.ResponseCustomerAsync(request.newPIN, cancellationToken);

            // Mapping Entity to DTO
            var response = _mapper.Map<CustomerResponseUpdateDTO>(customerFromdb);

            //Response
            return response;
        }
    }
}
