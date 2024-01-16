
using Abstraction;
using AutoMapper;
using Buisness.DTOs.Command.Customer;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Domen.Models.CommandModels;
using Buisness.DTOs.CommandDTOs.Customer;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;

namespace Buisness.Handlers.CustomerHandler
{
    public class _customer_Handler_delete : IRequestHandler<_customer_DeleteDTO_request, _customer_DeleteDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_customer_DeleteDTO_request> validator;
        private readonly IRepository_customer_remove customer_Repository_remove;
        private readonly IRepository_customer_respons customer_Repository_respons;
        private readonly IRepository_UnitOfWork unitOfWork_Repository;

        public _customer_Handler_delete(IMapper mapper, IValidator<_customer_DeleteDTO_request> validator, IRepository_customer_remove customer_Repository_remove, IRepository_customer_respons customer_Repository_respons, IRepository_UnitOfWork unitOfWork_Repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.customer_Repository_remove = customer_Repository_remove;
            this.customer_Repository_respons = customer_Repository_respons;
            this.unitOfWork_Repository = unitOfWork_Repository;
        }

        public async Task<_customer_DeleteDTO_respons> Handle(_customer_DeleteDTO_request customer_DeleteDTO_request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(customer_DeleteDTO_request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Deleting from database
            _customer_Model_write customerFromdb = await customer_Repository_remove._customer_Method_remove(customer_DeleteDTO_request._customer_PIN);

            //Mapping Entity to DTO
            var respons = mapper.Map<_customer_DeleteDTO_respons>(customerFromdb);

            //Saving changes
            await unitOfWork_Repository.Save(cancellationToken);

            //Respons
            return respons;

        }
    }
}
