using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.ProductCategory;

namespace GarageManagementAPI.Presentation.Validator.ProductCategory
{
    internal class ProductCategoryDtoForUpdateValidator : AbstractValidator<ProductCategoryDtoForUpdate>
    {
        public ProductCategoryDtoForUpdateValidator()
        {
            Include(new ProductCategoryDtoForManipulationValidator());
            AddStatusRules();
        }

        private void AddStatusRules()
        {
            RuleFor(pc => pc.Status)
               .NotEmpty()
               .WithMessage(ProductCategoryErrors.ProductCategoryStatusRequired)
               .WithErrorCode(nameof(ProductCategoryErrors.ProductCategoryStatusRequired))
               .Must(status => Enum.IsDefined(typeof(ProductCategoryStatus), status))
                .WithMessage(ProductCategoryErrors.ProductCategoryStatusInvalid)
                .WithErrorCode(nameof(ProductCategoryErrors.ProductCategoryStatusInvalid));
        }

    }
}
