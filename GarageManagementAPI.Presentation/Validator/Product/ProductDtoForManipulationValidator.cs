
using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.ErrorsConstant.Product;

namespace GarageManagementAPI.Presentation.Validator.Product
{
    internal class ProductDtoForManipulationValidator : AbstractValidator<ProductDtoForManipulation>
    {
        public ProductDtoForManipulationValidator()
        {
            AddNameRules();
        }

        private void AddNameRules()
        {
            RuleFor(b => b.ProductName)
                .NotEmpty()
                .WithMessage(ProductErrors.NameRequired)
                .WithErrorCode(nameof(ProductErrors.NameRequired));
        }
    }
}
