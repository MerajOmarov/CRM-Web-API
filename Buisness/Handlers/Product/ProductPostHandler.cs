
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
    public class ProductPostHandler : IRequestHandler<ProductPostDTOrequest, ProductPostDTOresponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductPostDTOrequest> _validator;
        private readonly IProductRepositoryPost _repositoryPost;
        private readonly IProductRepositoryResponse _repositoryResponse;
        private readonly IUnitOfWork _unitOfWork;

        public ProductPostHandler(
            IMapper mapper,
            IValidator<ProductPostDTOrequest> validator,
            IProductRepositoryPost product_Repository_post,
            IProductRepositoryResponse product_Repository_respons,
            IUnitOfWork unitOfWork_Respository)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryPost = product_Repository_post;
            _repositoryResponse = product_Repository_respons;
            _unitOfWork = unitOfWork_Respository;
        }

        public async Task<ProductPostDTOresponse> Handle(
            ProductPostDTOrequest request,
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
            var response = _mapper.Map<ProductPostDTOresponse>(productFromdb);

            //Respons
            return response;

        }
    }
}
