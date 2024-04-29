
using Abstraction;
using Abstraction.Abstractions.Write.Product;
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
        private readonly IProductUpdateRepository _repositoryUpdate;
        private readonly IProductResponseRepository _repositoryResponse;
        private readonly IUnitOfWork _unitOfWork;

        public ProductUpdateHandler(
            IMapper mapper,
            IValidator<ProductRequestUpdateDTO> validator,
            IProductUpdateRepository repositoryUpdate,
            IProductResponseRepository repositoryResponse,
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
            await _repositoryUpdate.UpdateProductAsync(request.OldBarcode,
                                                       request.NewBarcode,
                                                       request.NewPrice,
                                                       cancellationToken);

            //Saving changes
            await _unitOfWork.SaveAsync(cancellationToken);

            //Result
            var productFromdb = await _repositoryResponse.ResponseProductAsync(request.NewBarcode, cancellationToken);

            // Mapping Entity to DTO
            var response = _mapper.Map<ProductResponseUpdateDTO>(productFromdb);

            //Response
            return response;
        }
    }
}
