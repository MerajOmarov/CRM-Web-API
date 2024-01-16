
using Abstraction;
using AutoMapper;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.Models.CommandModels;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;

namespace Buisness.Handlers.ProductHandler
{
    public class _product_DeleteHandler : IRequestHandler<_product_DeleteDTO_request, _product_DeleteDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_product_DeleteDTO_request> validator;
        private readonly IRepository_product_remove product_Repository_remove;
        private readonly IRepository_UnitOfWork unitOfWork_Repository;

        public _product_DeleteHandler(IMapper mapper, IValidator<_product_DeleteDTO_request> validator, IRepository_product_remove product_Repository_remove, IRepository_UnitOfWork unitOfWork_Repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.product_Repository_remove = product_Repository_remove;
            this.unitOfWork_Repository = unitOfWork_Repository;
        }

        public async Task<_product_DeleteDTO_respons> Handle(_product_DeleteDTO_request product_DeleteDTO_request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(product_DeleteDTO_request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Deleting from database
            _product_Model_write productFromdb = await product_Repository_remove._product_Method_remove(product_DeleteDTO_request._product_Barcode);

            //Mapping Entity to DTO
            var respons = mapper.Map<_product_DeleteDTO_respons>(productFromdb);

            //Saving changes
            await unitOfWork_Repository.Save(cancellationToken);

            //Respons
            return respons;
        }
    }
}
