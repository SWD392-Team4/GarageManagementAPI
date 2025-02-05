using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Presentation.Validator.Workplace
{
    internal class WorkplaceDtoForCreationValidator : AbstractValidator<WorkplaceDtoForCreation>
    {
        public WorkplaceDtoForCreationValidator()
        {
            Include(new WorkplaceDtoForManipulationValidator());
        }
    }
}
