using Buisness.DTOs.Command.Order;
using FluentValidation;

namespace Buisness.FluentValidations.Order
{
    public class OrderPostDTOValidation : AbstractValidator<OrderRequestPostDTO>
    {
        public OrderPostDTOValidation()
        {
            RuleFor(x => x.Deedline)
            .NotEmpty().WithMessage("Validation Error: The Deedline field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The Deedline field must be datetime");

            RuleFor(x => x.CreatedTime)
            .NotEmpty().WithMessage("Validation Error: The CreatedTime field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The CreatedTime field must be datetime");

            RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Validation Error: The Code field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The Code field must be guid");

            RuleFor(x => x.ProductBarcode)
            .NotEmpty().WithMessage("Validation Error: The ProductBarcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The ProductBarcode field must be guid");

            RuleFor(x => x.CustomerPIN)
            .NotEmpty().WithMessage("Validation Error: The CustomerPIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The CustomerPIN field must be guid");
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
