using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Product;

namespace GarageManagementAPI.Presentation.Validator.Product
{
    internal class ProductDtoForCreationValidator : AbstractValidator<ProductDtoForCreation>
    {
        public ProductDtoForCreationValidator()
        {
            Include(new ProductDtoForManipulationValidator());
        }
    }
}
