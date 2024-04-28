
using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
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

            // Updating to database
            await _repositoryUpdate.UpdateCustomer(request.oldPIN, request.newPIN);

            //Saving changes
            await _unitOfWork.Save(cancellationToken);

            //Result
            var customerFromdb = await _repositotyResponse.ResponseCustomer(request.newPIN);

            // Mapping Entity to DTO
            var respons = _mapper.Map<CustomerResponseUpdateDTO>(customerFromdb);

            //Respons
            return respons;
        }
    }
}
