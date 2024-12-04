using Buisness.DTOs.Command.Customer;
using FluentValidation;

namespace Buisness.Buisness.FluentValidations.Customer
{
    public class UpdateCustomerRequestValidation : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Validation Error: Id can not be null");

            RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Validation Error: PhoneNumber field can not be null");
        }
    }
}
