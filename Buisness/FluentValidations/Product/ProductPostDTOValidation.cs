using Buisness.DTOs.CommandDTOs.Product;
using FluentValidation;

namespace Buisness.FluentValidations.Product
{
    public class ProductPostDTOValidation : AbstractValidator<PostProductRequest>
    {
        public ProductPostDTOValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Validation Error: The Name field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of Name field must be 3 simvols at least")
            .MaximumLength(60).WithMessage("Validation Error: The Lenght of Name field must be 60 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Name field must be string");

            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Validation Error: The Description field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of Description field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of Description field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Description field must be string");

            RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Validation Error: The Price field can not be null")
            .Must(BeAnDouble).WithMessage("Validation Error: The Price field must be double");

            RuleFor(x => x.Barcode)
            .NotEmpty().WithMessage("Validation Error: The Barcode field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The Barcode field must be guid");

            RuleFor(x => x.Videocard)
            .NotEmpty().WithMessage("Validation Error: The Videocard field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of Videocard field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of Videocard field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Videocard field must be string");

            RuleFor(x=>x.OperatingSystem)
            .NotEmpty().WithMessage("Validation Error: The OperatingSystem field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of OperatingSystem field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of OperatingSystem field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The OperatingSystem field must be string");

            RuleFor(x => x.Screen)
            .NotEmpty().WithMessage("Validation Error: The Screen field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of Screen field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of Screen field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Screen field must be string");

            RuleFor(x => x.Prosessor)
            .NotEmpty().WithMessage("Validation Error: The Prosessor field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of Prosessor field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of Prosessor field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Prosessor field must be string");

            RuleFor(x => x.Company)
            .NotEmpty().WithMessage("Validation Error: The Company field can not be null")
            .MinimumLength(3).WithMessage("Validation Error: The Lenght of Company field must be 3 simvols at least")
            .MaximumLength(100).WithMessage("Validation Error: The Lenght of Company field must be 100 simvols maximum")
            .Must(BeAnString).WithMessage("Validation Error: The Company field must be string");

            RuleFor(x => x.CreatedTime)
            .NotEmpty().WithMessage("Validation Error: The CreatedTime field can not be null")
            .Must(BeAnDatetime).WithMessage("Validation Error: The CreatedTime field must be datetime");
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
