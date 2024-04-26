using Buisness.DTOs.Command.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.FluentValidations.Customer
{
    public class CustomerPostDTOValidation : AbstractValidator<CustomerPostDTORequest>
    {
        public CustomerPostDTOValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Validation Error: The Name field can not be null")
            .MinimumLength(2).WithMessage("Validation Error: The Lenght of Name field must be 2 simvols at least")
            .MaximumLength(30).WithMessage("Validation Error: The Lenght of Name field must be 30 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Name field must be string");


            RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Validation Error: The Surname field can not be null")
            .MinimumLength(2).WithMessage("Validation Error: The Lenght of Surname field must be 2 simvols at least")
            .MaximumLength(30).WithMessage("Validation Error: The Lenght of Surname field must be 30 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Surname field must be string");


            RuleFor(x => x.PIN)
            .NotEmpty().WithMessage("Validation Error: The PIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The PIN field must be guid");


        }

        private bool BeAnString(string customerName)
        {
            return customerName.GetType() == typeof(string);
        }
        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }


    }
}
