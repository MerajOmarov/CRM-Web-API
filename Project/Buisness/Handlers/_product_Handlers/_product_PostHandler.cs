
using Abstraction;
using AutoMapper;
using Buisness.DTOs.CommandDTOs.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
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
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;

namespace Buisness.Handlers.ProductHandler
{
    public class _product_PostHandler : IRequestHandler<_product_PostDTO_request, _product_PostDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_product_PostDTO_request> validator;
        private readonly IRepository_product_post product_Repository_post;
        private readonly IRepository_product_respons product_Repository_respons;
        private readonly IRepository_UnitOfWork unitOfWork_Respository;

        public _product_PostHandler(IMapper mapper, IValidator<_product_PostDTO_request> validator, IRepository_product_post product_Repository_post, IRepository_product_respons product_Repository_respons, IRepository_UnitOfWork unitOfWork_Respository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.product_Repository_post = product_Repository_post;
            this.product_Repository_respons = product_Repository_respons;
            this.unitOfWork_Respository = unitOfWork_Respository;
        }

        public async Task<_product_PostDTO_respons> Handle(_product_PostDTO_request product_PostDTO_request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(product_PostDTO_request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }
            //Mapping DTO to Entity
            var productTodb = mapper.Map<_product_Model_write>(product_PostDTO_request);

            // Adding to database
            await product_Repository_post._product_Method_post(productTodb);

            //Saving changes
            await unitOfWork_Respository.Save(cancellationToken);

            //Result
            var productFromdb = await product_Repository_respons._product_Method_respons(productTodb._product_Barcode);

            // Mapping Entity to DTO
            var respons = mapper.Map<_product_PostDTO_respons>(productFromdb);

            //Respons
            return respons;

        }
    }
}
