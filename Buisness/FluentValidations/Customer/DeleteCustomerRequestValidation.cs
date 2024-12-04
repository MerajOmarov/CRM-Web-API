using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.DTOs.Write.Customer;
using FluentValidation;

namespace Buisness.Buisness.FluentValidations.Customer
{
    public class DeleteCustomerRequestValidation : AbstractValidator<DeleteCustomerRequest>
    {
        public DeleteCustomerRequestValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Validation Error: Id can not be null");
        }
    }
}
