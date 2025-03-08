using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;

namespace GarageManagementAPI.Presentation.Validator.PackageCondition
{
    public class PackageConditionDtoForCreationValidator : AbstractValidator<PackageConditionDtoForCreation>
    {
        public PackageConditionDtoForCreationValidator()
        {
            Include(new PackageConditionDtoForManipulationValidator());
        }
    }
}
