using Buisness.DTOs.Command.Product;
using FluentValidation;

namespace Buisness.FluentValidations.Product
{
    public class ProductUpdateDTOValidation : AbstractValidator<ProductRequestUpdateDTO>
    {
        public ProductUpdateDTOValidation()
        {
            RuleFor(x => x.OldBarcode)
            .NotEmpty().WithMessage("Validation Error: The OldBarcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The OldBarcode field must be guid");

            RuleFor(x => x.NewBarcode)
           .NotEmpty().WithMessage("Validation Error: The NewBarcode field can not be null")
           .Must(BeAnGuid).WithMessage("Validation Error: The NewBarcode field must be guid");

            RuleFor(x => x.NewPrice)
            .NotEmpty().WithMessage("Validation Error: The Price field can not be null")
            .Must(BeAnDouble).WithMessage("Validation Error: The Price field must be double");
        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }

        private bool BeAnDouble(double price)
        {
            return price.GetType() == typeof(double);
        }
    }
}
