using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;

namespace GarageManagementAPI.Presentation.Validator.ProductCategory
{
    internal class ProductCategoryDtoForCreationValidator : AbstractValidator<ProductCategoryDtoForCreation>
    {
        public ProductCategoryDtoForCreationValidator()
        {
            Include(new ProductCategoryDtoForManipulationValidator());
        }
    }
}
