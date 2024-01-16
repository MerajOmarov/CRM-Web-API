using Buisness.DTOs.Command.Order;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.OrderFluentValidation
{
    public class _order_Validation_postDTO : AbstractValidator<_order_PostDTO_request>
    {
        public _order_Validation_postDTO()
        {
            RuleFor(x => x._order_Deedline)
            .NotEmpty().WithMessage("Validation Error: The _order_Deedline field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The _order_Deedline field must be datetime");


            RuleFor(x => x._order_CreatedTime)
            .NotEmpty().WithMessage("Validation Error: The _order_CreatedTime field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The _order_CreatedTime field must be datetime");


            RuleFor(x => x._order_Code)
            .NotEmpty().WithMessage("Validation Error: The _order_Code field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _order_Code field must be guid");


            RuleFor(x => x._order_product_Barcode)
            .NotEmpty().WithMessage("Validation Error: The _order_product_Barcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _order_product_Barcode field must be guid");


            RuleFor(x => x._order_customer_PIN)
            .NotEmpty().WithMessage("Validation Error: The _order_customer_PIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _order_customer_PIN field must be guid");

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
