using Buisness.DTOs.Command.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.CustomerFluentValidation
{
    public class _customer_Validation_postDTO : AbstractValidator<_customer_PostDTO_request>
    {
        public _customer_Validation_postDTO()
        {
            RuleFor(x => x._customer_Name)
            .NotEmpty().WithMessage("Validation Error: The _customer_Name field can not be null")
            .MinimumLength(2).WithMessage("Validation Error: The Lenght of _customer_Name field must be 2 simvols at least")
            .MaximumLength(30).WithMessage("Validation Error: The Lenght of _customer_Name field must be 30 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _customer_Name field must be string");


            RuleFor(x => x._customer_Surname)
            .NotEmpty().WithMessage("Validation Error: The _customer_Surname field can not be null")
            .MinimumLength(2).WithMessage("Validation Error: The Lenght of _customer_Surname field must be 2 simvols at least")
            .MaximumLength(30).WithMessage("Validation Error: The Lenght of _customer_Surname field must be 30 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _customer_Surname field must be string");


            RuleFor(x => x._customer_PIN)
            .NotEmpty().WithMessage("Validation Error: The _customer_PIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _customer_PIN field must be guid");


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
