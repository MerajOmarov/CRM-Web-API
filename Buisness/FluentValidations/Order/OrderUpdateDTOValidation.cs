using Buisness.DTOs.Command.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.FluentValidations.Order
{
    public class OrderUpdateDTOValidation : AbstractValidator<OrderRequestUpdateDTO>
    {
        public OrderUpdateDTOValidation()
        {
            RuleFor(x => x.newDeedline)
            .NotEmpty().WithMessage("Validation Error: The newDeedline field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The newDeedline field must be datetime");

            RuleFor(x => x.oldCode)
            .NotEmpty().WithMessage("Validation Error: The oldCode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The oldCode field must be guid");

            RuleFor(x => x.newCode)
            .NotEmpty().WithMessage("Validation Error: The newCode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The newCode field must be guid");

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
