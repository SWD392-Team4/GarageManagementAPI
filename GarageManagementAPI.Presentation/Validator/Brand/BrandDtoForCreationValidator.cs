using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;


namespace GarageManagementAPI.Presentation.Validator.Brand
{
    internal class BrandDtoForCreationValidator : AbstractValidator<BrandDtoForCreation>
    {
        public BrandDtoForCreationValidator()
        {
            Include(new BrandDtoForManipulationValidator());
        }
    }
}
