using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Service
{
    public record class ServiceDto : BaseDto<ServiceDto>
    {
        public Guid Id { get; set; }

        public string? ServiceName { get; set; }

        [EnumDataType(typeof(ServiceCategory))]
        public ServiceCategory ServiceCategory { get; set; }

        public Guid CarPartId { get; set; }

        public string? PartName { get; set; }

        public string? Category { get; set; }

        public decimal Price { get; set; } = 0;

        [EnumDataType(typeof(WorkNature))]
        public WorkNature WorkNature { get; set; }

        [EnumDataType(typeof(ServiceAction))]
        public ServiceAction Action { get; set; }

        public string? Description { get; set; }

        public List<string>? ImageLink { get; set; }

        public int EstimatedHours { get; set; }

        [EnumDataType(typeof(ServiceStatus))]
        public ServiceStatus Status { get; set; }
    }
}
