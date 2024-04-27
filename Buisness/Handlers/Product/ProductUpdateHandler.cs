
using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using AutoMapper;
using Buisness.DTOs.Command.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.ProductHandler
{
    public class ProductUpdateHandler : IRequestHandler<ProductRequestUpdateDTO, ProductResponseUpdateDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductRequestUpdateDTO> _validator;
        private readonly IProductRepositoryUpdate _repositoryUpdate;
        private readonly IProductRepositoryResponse _repositoryResponse;
        private readonly IUnitOfWork _unitOfWork;

        public ProductUpdateHandler(
            IMapper mapper,
            IValidator<ProductRequestUpdateDTO> validator,
            IProductRepositoryUpdate repositoryUpdate,
            IProductRepositoryResponse repositoryResponse,
            IUnitOfWork unitOfWork_Repository)
        {
            _mapper = mapper;
            _validator = validator;
            _repositoryUpdate = repositoryUpdate;
            _repositoryResponse = repositoryResponse;
            _unitOfWork = unitOfWork_Repository;
        }

        public async Task<ProductResponseUpdateDTO> Handle(ProductRequestUpdateDTO request, CancellationToken cancellationToken)
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

            // Updating to database
            await _repositoryUpdate.UpdateProduct(request.OldBarcode, request.NewBarcode, request.NewPrice);

            //Saving changes
            await _unitOfWork.Save(cancellationToken);

            //Result
            var productFromdb = await _repositoryResponse.ResponseProduct(request.NewBarcode);

            // Mapping Entity to DTO
            var response = _mapper.Map<ProductResponseUpdateDTO>(productFromdb);

            //Respons
            return response;
        }
    }
}
