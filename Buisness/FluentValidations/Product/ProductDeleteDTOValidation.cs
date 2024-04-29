using Domen.DTOs.CommandDTOs.ProductDTOs;
using FluentValidation;

namespace Buisness.FluentValidations.Product
{
    public class ProductDeleteDTOValidation : AbstractValidator<ProductRequestDeleteDTO>
    {
        public ProductDeleteDTOValidation()
        {
            RuleFor(x => x.Barcode)
            .NotEmpty().WithMessage("Validation Error: The Barcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The Barcode field must be guid");
        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
