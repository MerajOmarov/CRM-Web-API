
using Abstraction;
using Abstraction.Abstractions.Write.Product;
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

            try
            {
                //Begin Transaction
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                // Adding to database
                await _repositoryPost.PostProductAsync(productTodb, cancellationToken);

                //Saving changes
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process"); throw new Exception("Failed Process");
            }

            //Result
            var productFromdb = await _repositoryResponse.ResponseProductAsync(productTodb.Barcode,cancellationToken);

            // Mapping Entity to DTO
            var response = _mapper.Map<ProductResponsePostDTO>(productFromdb);

            //Response
            return response;
        }
    }
}
