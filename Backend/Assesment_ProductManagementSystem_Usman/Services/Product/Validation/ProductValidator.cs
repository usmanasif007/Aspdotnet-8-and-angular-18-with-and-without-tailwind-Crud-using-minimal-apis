using Assesment_ProductManagementSystem_Usman.Services.Product.DTOs;
using FluentValidation;

namespace Assesment_ProductManagementSystem_Usman.Services.Product.Validation
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
             .NotNull().WithMessage("{PropertyName} is required")
             .NotEmpty().WithMessage("{PropertyName} is required")
             .Matches(@"^(?!\s*$).+").WithMessage("{PropertyName} cannot be empty or consist of only spaces.")
             .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^(?!\s*$).+").WithMessage("{PropertyName} cannot be empty or consist of only spaces.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

        }
    }
}
