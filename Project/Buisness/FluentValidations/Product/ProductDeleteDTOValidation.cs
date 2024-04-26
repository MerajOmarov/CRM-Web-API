using Domen.DTOs.CommandDTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.FluentValidations.Product
{
    public class ProductDeleteDTOValidation : AbstractValidator<ProductDeleteDTOrequest>
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
