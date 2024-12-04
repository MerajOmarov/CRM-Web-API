using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.DTOs.Write.Order;
using FluentValidation;

namespace Buisness.FluentValidations.Order
{
    public class DeleteOrderRequestValidation : AbstractValidator<DeleteOrderRequest>
    {
        public DeleteOrderRequestValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Validation Error: Id can not be null");
        }
    }
}
