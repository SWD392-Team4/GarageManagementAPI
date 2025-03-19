using FluentValidation;

using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;

namespace GarageManagementAPI.Presentation.Validator.Appointment
{
    public class AppointmentDtoForManipulationValidator : AbstractValidator<AppointmentDtoForManipulation>
    {
        public AppointmentDtoForManipulationValidator()
        {
            RuleFor(a => a.CustomerEmail)
                .NotEmpty()
                .WithMessage(AppointmentErrors.CustomerEmailRequired)
                .WithErrorCode(nameof(AppointmentErrors.CustomerEmailRequired))
                .EmailAddress()
                .WithErrorCode(nameof(AppointmentErrors.CustomerEmailInvalid))
                .WithMessage(AppointmentErrors.CustomerEmailInvalid);

            RuleFor(a => a.CustomerName)
                .NotEmpty()
                .WithMessage(AppointmentErrors.CustomerNameRequired)
                .WithErrorCode(nameof(AppointmentErrors.CustomerNameRequired));

            RuleFor(a => a.CustomerPhoneNumber)
                .NotEmpty()
                .WithMessage(AppointmentErrors.CustomerPhoneRequired)
                .WithErrorCode(nameof(AppointmentErrors.CustomerPhoneRequired))
                .Matches(@"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)")
                .WithMessage(AppointmentErrors.CustomerPhoneInvalid)
                .WithErrorCode(nameof(AppointmentErrors.CustomerPhoneInvalid));

            RuleFor(a => a.EstimatedAppointmentTime)
                .NotEmpty()
                .WithMessage(AppointmentErrors.EstimatedAppointmentTimeRequired)
                .WithErrorCode(nameof(AppointmentErrors.EstimatedAppointmentTimeRequired));

            RuleFor(a => a.CarModelId)
                .NotEmpty()
                .WithMessage(AppointmentErrors.CarModelIdRequired)
                .WithErrorCode(nameof(AppointmentErrors.CarModelIdRequired));

        }
    }
}
