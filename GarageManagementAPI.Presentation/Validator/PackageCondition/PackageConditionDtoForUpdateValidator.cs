using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;

namespace GarageManagementAPI.Presentation.Validator.PackageCondition
{
    public class PackageConditionDtoForUpdateValidator : AbstractValidator<PackageConditionDtoForUpdate>
    {
        public PackageConditionDtoForUpdateValidator()
        {
            Include(new PackageConditionDtoForManipulationValidator());
        }
    }
}
