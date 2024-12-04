using Domen.DTOs.Write.Product;
using FluentValidation;

namespace Buisness.FluentValidations.Product
{
    public class UpdateProductRequestValidation : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Validation Error: Id can not be null");

            RuleFor(x => x.NewPrice)
           .NotEmpty().WithMessage("Validation Error: NewPrice can not be null");

        }
    }
}
