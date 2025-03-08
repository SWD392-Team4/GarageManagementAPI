using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.CarCategory;

namespace GarageManagementAPI.Presentation.Validator.CarModel
{
    public class CarModelDtoForUpdateValidator : AbstractValidator<CarModelDtoForUpdate>
    {
        public CarModelDtoForUpdateValidator()
        {
            Include(new CarModelDtoForManipulationValidator());
            AddCarModelStatusRule();
        }
        private void AddCarModelStatusRule()
        {
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage(CarCategoryErrors.CarModelStatusRequired)
                .WithErrorCode(nameof(CarCategoryErrors.CarModelStatusRequired))
                .Must(c => Enum.IsDefined(c.GetType(), c!))
                .WithMessage(CarCategoryErrors.CarModelStatusInvalid)
                .WithErrorCode(nameof(CarCategoryErrors.CarModelStatusInvalid));
        }

    }
}
