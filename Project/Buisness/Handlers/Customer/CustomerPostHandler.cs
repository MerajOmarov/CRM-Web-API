﻿using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.Customer
{
    public class CustomerPostHandler : IRequestHandler<CustomerPostDTORequest, CustomerPostDTOResponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CustomerPostDTORequest> _validator;
        private readonly ICustomerRepositoryPost _repositoryPost;
        private readonly ICustomerRepositoryResponse _repositoryResponse;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerPostHandler(
            IMapper mapper,
            IValidator<CustomerPostDTORequest> validator,
            ICustomerRepositoryPost repositoryPost,
            ICustomerRepositoryResponse repositoryResponse,
            IUnitOfWork unitOfWork)
        {
           _mapper = mapper;
           _validator = validator;
           _repositoryPost = repositoryPost;
           _repositoryResponse = repositoryResponse;
           _unitOfWork = unitOfWork;
        }

        public async Task<CustomerPostDTOResponse> Handle(
            CustomerPostDTORequest request,
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
            var customerTodb = _mapper.Map<CustomerModelwrite>(request);

            // Adding to database
            await _repositoryPost.PostCustomer(customerTodb);

            //Saving changes
            await _unitOfWork.Save(cancellationToken);

            //Result
            var customerFromdb = await _repositoryResponse.ResponseCustomer(customerTodb.PIN);

            // Mapping Entity to DTO
            var response = _mapper.Map<CustomerPostDTOResponse>(customerFromdb);

            //Respons
            return response;
        }
    }
}