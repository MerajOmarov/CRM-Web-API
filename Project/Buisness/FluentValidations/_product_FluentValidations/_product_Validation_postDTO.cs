using Buisness.DTOs.Command.Product;
using Buisness.DTOs.CommandDTOs.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness._write_FluentValidations.ProductFluentValidation
{
    public class _product_Validation_postDTO : AbstractValidator<_product_PostDTO_request>
    {
        public _product_Validation_postDTO()
        {
            RuleFor(x => x._product_Name)
            .NotEmpty().WithMessage("Validation Error: The _product_Name field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of _product_Name field must be 3 simvols at least")
            .MaximumLength(60).WithMessage("Validation Error: The Lenght of _product_Name field must be 60 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _product_Name field must be string");

            RuleFor(x => x._product_Description)
            .NotEmpty().WithMessage("Validation Error: The _product_Description field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of _product_Description field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of _product_Description field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _product_Description field must be string");

            RuleFor(x => x._product_Price)
            .NotEmpty().WithMessage("Validation Error: The _product_Price field can not be null")
            .Must(BeAnDouble).WithMessage("Validation Error: The _product_Price field must be double");

            RuleFor(x => x._product_Barcode)
            .NotEmpty().WithMessage("Validation Error: The _product_Barcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The _product_Barcode field must be guid");

            RuleFor(x => x._product_Videocard)
            .NotEmpty().WithMessage("Validation Error: The _product_Videocard field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of _product_Videocard field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of _product_Videocard field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _product_Videocard field must be string");

            RuleFor(x=>x._product_OperatingSystem)
            .NotEmpty().WithMessage("Validation Error: The _product_OperatingSystem field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of _product_OperatingSystem field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of _product_OperatingSystem field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _product_OperatingSystem field must be string");

            RuleFor(x => x._product_Screen)
            .NotEmpty().WithMessage("Validation Error: The _product_Screen field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of _product_Screen field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of _product_Screen field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _product_Screen field must be string");

            RuleFor(x => x._product_Prosessor)
            .NotEmpty().WithMessage("Validation Error: The _product_Prosessor field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of _product_Prosessor field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of _product_Prosessor field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _product_Prosessor field must be string");

            RuleFor(x => x._product_Company)
            .NotEmpty().WithMessage("Validation Error: The _product_Company field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of _product_Company field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of _product_Company field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The _product_Company field must be string");

            RuleFor(x => x._product_CreatedTime)
            .NotEmpty().WithMessage("Validation Error: The _product_CreatedTime field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The _product_CreatedTime field must be datetime");

        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
        private bool BeAnString(string customerName)
        {
            return customerName.GetType() == typeof(string);
        }
        private bool BeAnDouble(double price)
        {
            return price.GetType() == typeof(double);
        }
        private bool BeAnDatetime(DateTime time)
        {
            return time.GetType() == typeof(DateTime);
        }
    }
}
