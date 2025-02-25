using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.Appointment
{
    public record AppointmentDto
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; } = "None";
        public string GarageName { get; set; } = "None";

        [EnumDataType(typeof(AppointmentStatus))]
        public AppointmentStatus Status { get; set; }

        public string CustomerName { get; set; } = "None";

        public string CustomerPhoneNumber { get; set; } = "None";

        public string CustomerEmail { get; set; } = "None";

        public string CarModelName { get; set; } = "None";

        public int Mileage { get; set; }

        public string CarLicensePlateNumber { get; set; } = "None";

        public string CarCondition { get; set; } = "None";

        public string? CanceledReason { get; set; } = "None";

        public DateTimeOffset? EstimatedAppointmentTime { get; set; }

        public DateTimeOffset? ActualAppointmentTime { get; set; }

        public DateTimeOffset? EstimatedEndTime { get; set; }

        public DateTimeOffset? ActualEndTime { get; set; }
        public decimal Price { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public AppointmentType AppointmentType { get; set; }
    }
}
