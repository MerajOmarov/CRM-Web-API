
using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using AutoMapper;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Customer
{
    public class CustomerDeleteHandler : IRequestHandler<CustomerRequestDeleteDTO, CustomerDeleteDTORespons>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerRequestDeleteDTO> _validator;
        private readonly ICustomerRepositoryRemove _repositoryRemove;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDeleteHandler(
            IMapper mapper,
            IValidator<CustomerRequestDeleteDTO> validator,
            ICustomerRepositoryRemove repositoryRemove,
            IUnitOfWork unitOfWork_Repository)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryRemove = repositoryRemove;
            _unitOfWork = unitOfWork_Repository;
        }

        public async Task<CustomerDeleteDTORespons> Handle(
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

            //Deleting from database
            CustomerWriteModel customerFromdb = await _repositoryRemove.RemoveCustomer(request.PIN);

            //Mapping Entity to DTO
            var respons = _mapper.Map<CustomerDeleteDTORespons>(customerFromdb);

            //Saving changes
            await _unitOfWork.Save(cancellationToken);

            //Respons
            return respons;
        }
    }
}
