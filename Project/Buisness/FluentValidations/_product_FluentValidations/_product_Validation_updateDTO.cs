using Buisness.DTOs.Command.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.ProductFluentValidation
{
    public class _product_Validation_updateDTO : AbstractValidator<_product_UpdateDTO_request>
    {
        public _product_Validation_updateDTO()
        {
            RuleFor(x => x._product_oldBarcode)
            .NotEmpty().WithMessage("Validation Error: The _product_oldBarcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _product_oldBarcode field must be guid");

            RuleFor(x => x._product_newBarcode)
           .NotEmpty().WithMessage("Validation Error: The _product_newBarcode field can not be null")
           .Must(BeAnGuid).WithMessage("Validation Error: The _product_newBarcode field must be guid");

            RuleFor(x => x._product_newPrice)
            .NotEmpty().WithMessage("Validation Error: The _product_Price field can not be null")
            .Must(BeAnDouble).WithMessage("Validation Error: The _product_Price field must be double");
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
