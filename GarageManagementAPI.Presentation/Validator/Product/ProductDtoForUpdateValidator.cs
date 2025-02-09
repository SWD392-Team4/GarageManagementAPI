using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.ErrorsConstant.Product;
using GarageManagementAPI.Shared.Enums;

namespace GarageManagementAPI.Presentation.Validator.Product
{
    internal class ProductDtoForUpdateValidator : AbstractValidator<ProductDtoForUpdate>
    {
        public ProductDtoForUpdateValidator()
        {
            Include(new ProductDtoForManipulationValidator());
            AddStatusRules();
        }

        private void AddStatusRules()
        {
            RuleFor(b => b.Status)
               .NotEmpty()
               .WithMessage(ProductErrors.ProductStatusRequired)
               .WithErrorCode(nameof(ProductErrors.ProductStatusRequired))
               .Must(status => Enum.IsDefined(typeof(SystemStatus), status))
                .WithMessage(ProductErrors.ProductStatusInvalid)
                .WithErrorCode(nameof(ProductErrors.ProductStatusInvalid));
        }

    }
}
