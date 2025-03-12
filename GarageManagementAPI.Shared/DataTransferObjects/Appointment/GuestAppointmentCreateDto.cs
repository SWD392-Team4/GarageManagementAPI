using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public class AppointmentDtoCreation
    {
        public Guid? CarModelId { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerPhoneNumber { get; set; }

        public string? CustomerEmail { get; set; }

        public DateTimeOffset? EstimatedAppointmentTime { get; set; }

        public IEnumerable<ServiceInAppointmentDto>? Services { get; set; }

        public IEnumerable<Guid>? PackageIds { get; set; }
    }

    public class AppointmentCarInfoUpdateDto
    {
        public Guid? CarModelId { get; set; }

        public int? Mileage { get; set; }

        public string? CarLicensePlateNumber { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }
    }

    public class AppointmentDtoCreationWIthFullInformation
    {
        public Guid CarModelId { get; set; }

        public int? Mileage { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerPhoneNumber { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public DateTimeOffset EstimatedAppointmentTime { get; set; }

        public string? CarLicensePlateNumber { get; set; }

        public IEnumerable<ServiceInAppointmentDto>? Services { get; set; }

        public IEnumerable<Guid>? PackageIds { get; set; }

    }

    public class AppointmentConfirmationDto
    {
        public string? CanceledReason { get; set; } = string.Empty;

        public DateTimeOffset? EstimatedAppointmentTime { get; set; }

    }


}
