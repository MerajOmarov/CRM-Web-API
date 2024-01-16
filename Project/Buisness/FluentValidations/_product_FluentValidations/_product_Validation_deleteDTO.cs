using Domen.DTOs.CommandDTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.ProductFluentValidation
{
    public class _product_Validation_deleteDTO : AbstractValidator<_product_DeleteDTO_request>
    {
        public _product_Validation_deleteDTO()
        {
            RuleFor(x => x._product_Barcode)
            .NotEmpty().WithMessage("Validation Error: The _product_Barcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _product_Barcode field must be guid");
        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
