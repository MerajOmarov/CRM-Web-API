
using Abstraction;
using Abstraction.Abstractions.Write.Product;
using AutoMapper;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.Models.CommandModels;
using FluentValidation;
using MediatR;

namespace Buisness.Handlers.ProductHandler
{
    public class ProductDeleteHandler : IRequestHandler<ProductRequestDeleteDTO, ProductResponseDeleteDTO>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductRequestDeleteDTO> _validator;
        private readonly IProductRemoveRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductDeleteHandler(
            IMapper mapper,
            IValidator<ProductRequestDeleteDTO> validator,
            IProductRemoveRepository repository,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _validator = validator;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponseDeleteDTO> Handle(
            ProductRequestDeleteDTO request,
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

            ProductWriteModel productFromdb = new();

            try
            {
                //Begin Transaction
                await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken);

                //Deleting from database
                productFromdb = await _repository.RemoveProductAsync(request.Barcode, cancellationToken);

                //Save changes
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsycn(cancellationToken);

                throw new Exception("Failed Process");
            }
           
            //Mapping Entity to DTO
            var response = _mapper.Map<ProductResponseDeleteDTO>(productFromdb);

            //Saving changes
            await _unitOfWork.SaveAsync(cancellationToken);

            //Respons
            return response;
        }
    }
}
