using Domen.DTOs.CommandDTOs.OrderDTOs;
using FluentValidation;

namespace Buisness.FluentValidations.Order
{
    public class OrderDeleteDTOValidation : AbstractValidator<OrderRequestDeleteDTO>
    {
        public OrderDeleteDTOValidation()
        {
            RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Validation Error: The Code field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The Code field must be guid");
        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
