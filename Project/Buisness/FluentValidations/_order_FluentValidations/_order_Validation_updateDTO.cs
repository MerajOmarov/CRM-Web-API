using Buisness.DTOs.Command.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.OrderFluentValidation
{
    public class _order_Validation_updateDTO : AbstractValidator<_order_UpdateDTO_request>
    {
        public _order_Validation_updateDTO()
        {
            RuleFor(x => x._order_newDeedline)
            .NotEmpty().WithMessage("Validation Error: The _order_newDeedline field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The _order_newDeedline field must be datetime");

            RuleFor(x => x._order_oldCode)
            .NotEmpty().WithMessage("Validation Error: The _order_oldCode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _order_oldCode field must be guid");

            RuleFor(x => x._order_newCode)
            .NotEmpty().WithMessage("Validation Error: The _order_newCode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _order_newCode field must be guid");

        }

        private bool BeAnDatetime(DateTime time)
        {
            return time.GetType() == typeof(DateTime);
        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
