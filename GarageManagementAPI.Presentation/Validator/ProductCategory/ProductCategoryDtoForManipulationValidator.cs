using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using GarageManagementAPI.Shared.ErrorsConstant.ProductCategory;


namespace GarageManagementAPI.Presentation.Validator.ProductCategory
{
    public class ProductCategoryDtoForManipulationValidator : AbstractValidator<ProductCategoryDtoForManipulation>
    {
        public ProductCategoryDtoForManipulationValidator()
        {
            AddNameRules();
        }

        private void AddNameRules()
        {
            RuleFor(pc => pc.Category)
                .NotEmpty()
                .WithMessage(ProductCategoryErrors.ProductCategorNameRequired)
                .WithErrorCode(nameof(ProductCategoryErrors.ProductCategorNameRequired));
        }
    }
}
