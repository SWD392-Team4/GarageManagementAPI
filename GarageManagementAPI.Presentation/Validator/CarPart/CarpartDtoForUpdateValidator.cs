using FluentValidation;
using GarageManagementAPI.Presentation.Validator.CarPart;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.CarPart;

namespace GarageManagementAPI.Presentation.Validator.CarPart
{
    public class CarpartDtoForUpdateValidator : AbstractValidator<CarPartDtoForUpdate>
    {
        public CarpartDtoForUpdateValidator()
        {
            Include(new CarPartDtoForManipulationValidator());
            AddStatusRules();
        }

        private void AddStatusRules()
        {
            RuleFor(b => b.Status)
               .NotEmpty()
               .WithMessage(CarPartErrors.CarPartStatusRequired)
               .WithErrorCode(nameof(CarPartErrors.CarPartStatusRequired))
               .Must(status => Enum.IsDefined(typeof(CarPartStatus), status))
                .WithMessage(CarPartErrors.CarPartStatusInvalid)
                .WithErrorCode(nameof(CarPartErrors.CarPartStatusInvalid));
        }
    }
}
