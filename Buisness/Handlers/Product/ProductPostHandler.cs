﻿
using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using AutoMapper;
using Buisness.DTOs.CommandDTOs.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.ProductHandler
{
    public class ProductPostHandler : IRequestHandler<ProductRequestPostDTO, ProductResponsePostDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductRequestPostDTO> _validator;
        private readonly IProductPostRepository _repositoryPost;
        private readonly IProductResponseRepository _repositoryResponse;
        private readonly IUnitOfWork _unitOfWork;

        public ProductPostHandler(
            IMapper mapper,
            IValidator<ProductRequestPostDTO> validator,
            IProductPostRepository product_Repository_post,
            IProductResponseRepository product_Repository_respons,
            IUnitOfWork unitOfWork_Respository)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryPost = product_Repository_post;
            _repositoryResponse = product_Repository_respons;
            _unitOfWork = unitOfWork_Respository;
        }

        public async Task<ProductResponsePostDTO> Handle(
            ProductRequestPostDTO request,
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
            var productTodb = _mapper.Map<ProductWriteModel>(request);

            // Adding to database
            await _repositoryPost.PostProduct(productTodb);

            //Saving changes
            await _unitOfWork.Save(cancellationToken);

            //Result
            var productFromdb = await _repositoryResponse.ResponseProduct(productTodb.Barcode);

            // Mapping Entity to DTO
            var response = _mapper.Map<ProductResponsePostDTO>(productFromdb);

            //Respons
            return response;

        }
    }
}
