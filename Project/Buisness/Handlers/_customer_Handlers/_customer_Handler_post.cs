using Abstraction;
using AutoMapper;
using Azure.Core;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.Models.CommandModels;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories.CommandRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;

namespace Buisness.Handlers.CustomerHandler
{
    public class _customer_Handler_post : IRequestHandler<_customer_PostDTO_request, _customer_PostDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_customer_PostDTO_request> validator;
        private readonly IRepository_customer_post customer_Repository_post;
        private readonly IRepository_customer_respons customer_Repository_respons;
        private readonly IRepository_UnitOfWork unitOfWork_Repository;

        public _customer_Handler_post(IMapper mapper, IValidator<_customer_PostDTO_request> validator, IRepository_customer_post customer_Repository_post, IRepository_customer_respons customer_Repository_respons, IRepository_UnitOfWork unitOfWork_Repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.customer_Repository_post = customer_Repository_post;
            this.customer_Repository_respons = customer_Repository_respons;
            this.unitOfWork_Repository = unitOfWork_Repository;
        }

        public async Task<_customer_PostDTO_respons> Handle(_customer_PostDTO_request customer_PostDTO_request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(customer_PostDTO_request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Mapping DTO to Entity
            var customerTodb = mapper.Map<_customer_Model_write>(customer_PostDTO_request);

            // Adding to database
            await customer_Repository_post._customer_Method_post(customerTodb);

            //Saving changes
            await unitOfWork_Repository.Save(cancellationToken);

            //Result
            var customerFromdb = await customer_Repository_respons._customer_Method_respons(customerTodb._customer_PIN);

            // Mapping Entity to DTO
            var respons = mapper.Map<_customer_PostDTO_respons>(customerFromdb);

            //Respons
            return respons;
        }
    }
}
