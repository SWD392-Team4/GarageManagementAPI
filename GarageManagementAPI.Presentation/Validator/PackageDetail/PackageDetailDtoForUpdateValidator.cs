using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.PackageDetail;

namespace GarageManagementAPI.Presentation.Validator.PackageDetail
{
    public class PackageDetailDtoForUpdateValidator : AbstractValidator<PackageDetailDtoForUpdate>
    {
        public PackageDetailDtoForUpdateValidator()
        {
            Include(new PackageDetailDtoForManipulationValidator());
        }
    }
}
