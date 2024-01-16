
using Abstraction;
using AutoMapper;
using Buisness.DTOs.Command.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Infrastructure.Repositories.CommandRepositories;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;

namespace Buisness.Handlers.ProductHandler
{
    public class _product_PutHandler : IRequestHandler<_product_UpdateDTO_request, _product_UpdateDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_product_UpdateDTO_request> validator;
        private readonly IRepository_product_update product_Repository_update;
        private readonly IRepository_product_respons product_Repository_respons;
        private readonly IRepository_UnitOfWork unitOfWork_Repository;

        public _product_PutHandler(IMapper mapper, IValidator<_product_UpdateDTO_request> validator, IRepository_product_update product_Repository_update, IRepository_product_respons product_Repository_respons, IRepository_UnitOfWork unitOfWork_Repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.product_Repository_update = product_Repository_update;
            this.product_Repository_respons = product_Repository_respons;
            this.unitOfWork_Repository = unitOfWork_Repository;
        }

        public async Task<_product_UpdateDTO_respons> Handle(_product_UpdateDTO_request product_UpdateDTO_request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(product_UpdateDTO_request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            // Updating to database
            await product_Repository_update._product_Method_update(product_UpdateDTO_request._product_oldBarcode, product_UpdateDTO_request._product_newBarcode, product_UpdateDTO_request._product_newPrice);

            //Saving changes
            await unitOfWork_Repository.Save(cancellationToken);

            //Result
            var productFromdb = await product_Repository_respons._product_Method_respons(product_UpdateDTO_request._product_newBarcode);

            // Mapping Entity to DTO
            var respons = mapper.Map<_product_UpdateDTO_respons>(productFromdb);

            //Respons
            return respons;
        }
    }
}
