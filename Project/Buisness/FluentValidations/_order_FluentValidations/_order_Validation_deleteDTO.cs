using Domen.DTOs.CommandDTOs.OrderDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.OrderFluentValidation
{
    public class _order_Validation_deleteDTO : AbstractValidator<_order_DeleteDTO_request>
    {
        public _order_Validation_deleteDTO()
        {
            RuleFor(x => x._order_Code)
            .NotEmpty().WithMessage("Validation Error: The _order_Code field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _order_Code field must be guid");
        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
