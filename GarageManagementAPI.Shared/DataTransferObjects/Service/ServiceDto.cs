using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Service
{
    public record class ServiceDto : BaseDto<ServiceDto>
    {
        public Guid Id { get; set; }
        public string ServiceCategory { get; set; } = null!;

        public string ServiceName { get; set; } = null!;

        public string WorkNature { get; set; } = null!;

        public string Action { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int EstimatedHours { get; set; }
        [EnumDataType(typeof(ServiceStatus))]
        public ServiceStatus Status { get; set; }
    }
}
