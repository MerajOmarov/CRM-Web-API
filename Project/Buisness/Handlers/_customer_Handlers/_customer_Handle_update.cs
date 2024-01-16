
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
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.Models.CommandModels;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;

namespace Buisness.Handlers.CustomerHandler
{
    public class _customer_Handle_update : IRequestHandler<_customer_UpdateDTO_request, _customer_UpdateDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_customer_UpdateDTO_request> validator;
        private readonly IRepository_customer_update customer_Repository_update;
        private readonly IRepository_customer_respons customer_Repositoty_respons;
        private readonly IRepository_UnitOfWork unitOfWork_Repository;

        public _customer_Handle_update(IMapper mapper, IValidator<_customer_UpdateDTO_request> validator, IRepository_customer_update customer_Repository_update, IRepository_customer_respons customer_Repositoty_respons, IRepository_UnitOfWork unitOfWork_Repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.customer_Repository_update = customer_Repository_update;
            this.customer_Repositoty_respons = customer_Repositoty_respons;
            this.unitOfWork_Repository = unitOfWork_Repository;
        }

        public async Task<_customer_UpdateDTO_respons> Handle(_customer_UpdateDTO_request customer_UpdateDTO_Request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(customer_UpdateDTO_Request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            // Updating to database
            await customer_Repository_update._customer_Method_update(customer_UpdateDTO_Request._customer_oldPIN, customer_UpdateDTO_Request._customer_newPIN);

            //Saving changes
            await unitOfWork_Repository.Save(cancellationToken);

            //Result
            var customerFromdb = await customer_Repositoty_respons._customer_Method_respons(customer_UpdateDTO_Request._customer_newPIN);

            // Mapping Entity to DTO
            var respons = mapper.Map<_customer_UpdateDTO_respons>(customerFromdb);

            //Respons
            return respons;
        }
    }
}
