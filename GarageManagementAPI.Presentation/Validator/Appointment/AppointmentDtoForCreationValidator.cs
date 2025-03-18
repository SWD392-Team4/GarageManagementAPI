using FluentValidation;

using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.ErrorsConstant.Appointment;

namespace GarageManagementAPI.Presentation.Validator.Appointment
{
    public class AppointmentDtoForCreationValidator : AbstractValidator<AppointmentDtoForCreation>
    {
        public AppointmentDtoForCreationValidator()
        {
            Include(new AppointmentDtoForManipulationValidator());

            RuleFor(a => new { a.Services, a.Packages })
                 .Must(x => (x.Services != null && x.Services.Any()) || (x.Packages != null && x.Packages.Any()))
                 .WithErrorCode(nameof(AppointmentErrors.InvalidAppointment))
                 .WithMessage(AppointmentErrors.InvalidAppointment);

            // Validate Services collection if present
            When(a => a.Services != null && a.Services.Any(), () =>
            {
                // Check for duplicate ServiceIds
                RuleFor(a => a.Services)
                 .Must(services => !services.GroupBy(s => s.ServiceId).Any(g => g.Count() > 1))
                 .WithErrorCode(nameof(AppointmentErrors.AppointmentServiceDuplicate))
                 .WithMessage(appointment =>
                 {
                     if (appointment.Services == null) return AppointmentErrors.AppointmentServiceDuplicate;

                     var duplicateServiceIds = appointment.Services
                         .GroupBy(s => s.ServiceId)
                         .Where(g => g.Count() > 1)
                         .Select(g => g.Key)
                         .FirstOrDefault();

                     return string.Format(AppointmentErrors.AppointmentServiceDuplicate, duplicateServiceIds);
                 });

                // Validate each service's replacement parts
                RuleForEach(a => a.Services)
                    .ChildRules(service =>
                    {
                        service.When(s => s.ReplacementParts != null && s.ReplacementParts.Any(), () =>
                        {
                            service.RuleFor(s => s.ReplacementParts)
                                .Must(parts => !parts.Where(p => p.ProductId.HasValue)
                                    .GroupBy(p => p.ProductId)
                                    .Any(g => g.Count() > 1))
                                .WithErrorCode(nameof(AppointmentErrors.AppointmentHasDuplicateProductInService))
                                .WithMessage((s, parts) =>
                                {
                                    if (s.ReplacementParts == null) return AppointmentErrors.AppointmentHasDuplicateProductInService;
                                    var duplicateProductIds = s.ReplacementParts
                                        .Where(p => p.ProductId.HasValue)
                                        .GroupBy(p => p.ProductId)
                                        .Where(g => g.Count() > 1)
                                        .Select(g => g.Key)
                                        .FirstOrDefault();
                                    return string.Format(AppointmentErrors.AppointmentHasDuplicateProductInService, s.ServiceId, duplicateProductIds);
                                });
                        });
                    });
            });

            // Validate Packages collection if present
            When(a => a.Packages != null && a.Packages.Any(), () =>
            {
                // Check for duplicate PackageIds
                RuleFor(a => a.Packages)
                    .Must(packages => !packages.GroupBy(p => p.PackageId).Any(g => g.Count() > 1))
                    .WithErrorCode(nameof(AppointmentErrors.AppointmentPackageDuplicate))
                    .WithMessage(appointment =>
                    {
                        if (appointment.Packages == null) return AppointmentErrors.AppointmentPackageDuplicate;
                        var duplicatePackageIds = appointment.Packages
                            .GroupBy(p => p.PackageId)
                            .Where(g => g.Count() > 1)
                            .Select(g => g.Key)
                            .FirstOrDefault();
                        return string.Format(AppointmentErrors.AppointmentPackageDuplicate, duplicatePackageIds);
                    });
            });
        }
    }
}
