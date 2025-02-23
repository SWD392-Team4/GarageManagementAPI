using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;
using GarageManagementAPI.Shared.ErrorsConstant.CarPart;

namespace GarageManagementAPI.Presentation.Validator.CarPart
{
    internal class CarPartDtoForManipulationValidator : AbstractValidator<CarPartDtoForManipulation>
    {
        public CarPartDtoForManipulationValidator()
        {
            AddNameRules();
        }

        private void AddNameRules()
        {
            RuleFor(c => c.PartName)
                .NotEmpty()
                .WithMessage(CarPartErrors.CarPartNameRequired)
                .WithErrorCode(nameof(CarPartErrors.CarPartNameRequired));
        }
    }
}
