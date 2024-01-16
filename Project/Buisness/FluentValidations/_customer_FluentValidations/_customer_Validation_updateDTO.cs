using Buisness.DTOs.Command.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.CustomerFluentValidation
{
    public class _customer_Validation_updateDTO : AbstractValidator<_customer_UpdateDTO_request>
    {
        public _customer_Validation_updateDTO()
        {
            RuleFor(x => x._customer_oldPIN)
            .NotEmpty().WithMessage("Validation Error: The _customer_oldPIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _customer_oldPIN field must be guid");

            RuleFor(x => x._customer_newPIN)
           .NotEmpty().WithMessage("Validation Error: The _customer_newPIN field can not be null")
           .Must(BeAnGuid).WithMessage("Validation Error: The _customer_newPIN field must be guid");
        }
        private bool BeAnGuid(Guid time)
        {
            return time.GetType() == typeof(Guid);
        }
    }
}
