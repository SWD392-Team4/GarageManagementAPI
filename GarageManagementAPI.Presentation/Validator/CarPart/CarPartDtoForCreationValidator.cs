using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;

namespace GarageManagementAPI.Presentation.Validator.CarPart
{
    internal class CarPartDtoForCreationValidator : AbstractValidator<CarPartDtoForCreation>
    {
        public CarPartDtoForCreationValidator()
        {
            Include(new CarPartDtoForManipulationValidator());
        }
    }
}
