using Domen.DTOs.CommandDTOs.CustomerDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Buisness.FluentValidations.Customer
{
    public class CustomerRemoveDTOValidation : AbstractValidator<CustomerDeleteDTORequest>
    {
        public CustomerRemoveDTOValidation()
        {
            RuleFor(x => x.PIN)
            .NotEmpty().WithMessage("Validation Error: The PIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The PIN field must be guid");

        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
