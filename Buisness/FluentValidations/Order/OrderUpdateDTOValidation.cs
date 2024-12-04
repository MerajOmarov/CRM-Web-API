using Buisness.DTOs.Command.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.FluentValidations.Order
{
    public class OrderUpdateDTOValidation : AbstractValidator<UpdateOrderRequest>
    {
        public OrderUpdateDTOValidation()
        {
            RuleFor(x => x.newDeedline)
            .NotEmpty().WithMessage("Validation Error: The newDeedline field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The newDeedline field must be datetime");

            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Validation Error: Id can not be null");

            RuleFor(x => x.newCode)
            .NotEmpty().WithMessage("Validation Error: The newCode field can not be null");
        }

        private bool BeAnDatetime(DateTime time)
        {
            return time.GetType() == typeof(DateTime);
        }
    }
}
