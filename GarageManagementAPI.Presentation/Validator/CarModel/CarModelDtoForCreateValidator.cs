using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;

namespace GarageManagementAPI.Presentation.Validator.CarModel
{
    public class CarModelDtoForCreateValidator : AbstractValidator<CarModelDtoForCreate>
    {
        public CarModelDtoForCreateValidator()
        {
            Include(new CarModelDtoForManipulationValidator());
        }
    }
}
