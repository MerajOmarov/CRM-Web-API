using Buisness.DTOs.Command.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.FluentValidations.Product
{
    public class ProductUpdateDTOValidation : AbstractValidator<ProductUpdateDTOrequest>
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
