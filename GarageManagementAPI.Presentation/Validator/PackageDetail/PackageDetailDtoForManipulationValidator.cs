using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.PackageDetail;
using GarageManagementAPI.Shared.ErrorsConstant.Package;

namespace GarageManagementAPI.Presentation.Validator.PackageDetail
{
    public class PackageDetailDtoForManipulationValidator : AbstractValidator<PackageDetailDtoForManipulation>
    {
        public PackageDetailDtoForManipulationValidator()
        {
            RuleFor(p => p.ServiceList)
                .NotEmpty()
                .WithErrorCode(nameof(PackageErrors.ServiceListRequired))
                .WithMessage(PackageErrors.ServiceListRequired);
        }
    }
}
