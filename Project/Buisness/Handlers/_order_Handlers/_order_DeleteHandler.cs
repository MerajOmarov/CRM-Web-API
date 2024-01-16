
using Abstraction;
using AutoMapper;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Models.CommandModels;
using Infrastructure.Repositories.CommandRepositories;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;

namespace Buisness.Handlers.OrderHandler
{
    public class _order_DeleteHandler : IRequestHandler<_order_DeleteDTO_request, _order_DeleteDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_order_DeleteDTO_request> validator;
        private readonly IRepository_order_remove order_Repository_remove;
        private readonly IRepository_UnitOfWork unitOfWork_Repository;

        public _order_DeleteHandler(IMapper mapper, IValidator<_order_DeleteDTO_request> validator, IRepository_order_remove order_Repository_remove, IRepository_UnitOfWork unitOfWork_Repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.order_Repository_remove = order_Repository_remove;
            this.unitOfWork_Repository = unitOfWork_Repository;
        }

        public async Task<_order_DeleteDTO_respons> Handle(_order_DeleteDTO_request request, CancellationToken cancellationToken)
        {

            //Validation
            var validationOfRequest = await validator.ValidateAsync(request);
            if (!validationOfRequest.IsValid)
            {
                foreach (var error in validationOfRequest.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Deleting from database
            _order_Model_write orderFromdb = await order_Repository_remove._order_Method_remove(request._order_Code);

            //Mapping Entity to DTO
            var respons = mapper.Map<_order_DeleteDTO_respons>(orderFromdb);

            //Saving changes
            await unitOfWork_Repository.Save(cancellationToken);

            //Respons
            return respons;
        }
    }
}
