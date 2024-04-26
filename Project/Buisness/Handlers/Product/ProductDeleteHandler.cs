
using Abstraction;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using AutoMapper;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.ProductHandler
{
    public class ProductDeleteHandler : IRequestHandler<ProductDeleteDTOrequest, ProductDeleteDTOresponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDeleteDTOrequest> _validator;
        private readonly IProductRepositoryRemove _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductDeleteHandler(
            IMapper mapper,
            IValidator<ProductDeleteDTOrequest> validator,
            IProductRepositoryRemove repository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDeleteDTOresponse> Handle(
            ProductDeleteDTOrequest request,
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

            //Deleting from database
            ProductModelwrite productFromdb = await _repository.RemoveProduct(request.Barcode);

            //Mapping Entity to DTO
            var response = _mapper.Map<ProductDeleteDTOresponse>(productFromdb);

            //Saving changes
            await _unitOfWork.Save(cancellationToken);

            //Respons
            return response;
        }
    }
}
