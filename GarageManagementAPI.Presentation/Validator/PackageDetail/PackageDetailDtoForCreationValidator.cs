using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.PackageDetail;

namespace GarageManagementAPI.Presentation.Validator.PackageDetail
{
    public class PackageDetailDtoForCreationValidator : AbstractValidator<PackageDetailDtoForCreation>
    {
        public PackageDetailDtoForCreationValidator()
        {
            Include(new PackageDetailDtoForManipulationValidator());
        }
    }
}
