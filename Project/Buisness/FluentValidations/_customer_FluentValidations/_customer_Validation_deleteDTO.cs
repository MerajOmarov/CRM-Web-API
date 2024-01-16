using Domen.DTOs.CommandDTOs.CustomerDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.CustomerFluentValidation
{
    public class _customer_DeleteDTO_Validation : AbstractValidator<_customer_DeleteDTO_request>
    {
        public _customer_DeleteDTO_Validation()
        {
            RuleFor(x => x._customer_PIN)
            .NotEmpty().WithMessage("Validation Error: The _customer_PIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _customer_PIN field must be guid");

        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
