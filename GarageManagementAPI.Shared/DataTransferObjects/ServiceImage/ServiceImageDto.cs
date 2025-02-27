using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceImage
{
    public record class ServiceImageDto : BaseDto<ServiceImageDto>
    {
        public Guid Id { get; set; }
        public string? ImageLink { get; set; } = "N/A";
        [EnumDataType(typeof(ServiceImageStatus))]
        public ServiceImageStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
