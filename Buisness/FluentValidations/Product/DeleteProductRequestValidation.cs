using Domen.DTOs.CommandDTOs.ProductDTOs;
using Domen.DTOs.Write.Product;
using FluentValidation;

namespace Buisness.FluentValidations.Product
{
    public class DeleteProductRequestValidation : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductRequestValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Validation Error: The Barcode field can not be null");
        }
    }
}
