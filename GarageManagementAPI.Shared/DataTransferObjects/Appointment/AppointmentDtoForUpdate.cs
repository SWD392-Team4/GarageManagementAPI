using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDtoForUpdate
    {
        public string? CustomerName { get; set; }

        public string? CustomerPhoneNumber { get; set; }

        public string? CustomerEmail { get; set; }

        public int Mileage { get; set; }

        public string? CarLicensePlateNumber { get; set; }

        public string? CarCondition { get; set; }

        public string? CanceledReason { get; set; }

        public Guid CarModelId { get; set; }

        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus Status { get; set; }
    }
}
