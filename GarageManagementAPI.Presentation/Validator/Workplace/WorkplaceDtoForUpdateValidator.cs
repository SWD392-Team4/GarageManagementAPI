using FluentValidation;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using GarageManagementAPI.Shared.ErrorsConstant.Workplace;

namespace GarageManagementAPI.Presentation.Validator.Workplace
{
    internal class WorkplaceDtoForUpdateValidator : AbstractValidator<WorkplaceDtoForUpdate>
    {
        public WorkplaceDtoForUpdateValidator()
        {
            Include(new WorkplaceDtoForManipulationValidator());
            AddStatusRules();
        }

        private void AddStatusRules()
        {
            RuleFor(w => w.Status)
               .NotEmpty()
               .WithMessage(WorkplaceErrors.WorkplaceStatusRequired)
               .WithErrorCode(nameof(WorkplaceErrors.WorkplaceStatusRequired))
               .Must(status => Enum.IsDefined(typeof(WorkplaceStatus), status))
                .WithMessage(WorkplaceErrors.WorkplaceStatusInvalid)
                .WithErrorCode(nameof(WorkplaceErrors.WorkplaceStatusInvalid));
        }
    }
}
