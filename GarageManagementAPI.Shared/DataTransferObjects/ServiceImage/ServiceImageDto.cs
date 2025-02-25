using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.ServiceImage
{
    public record class ServiceImageDto
    {
        public Guid ServiceId { get; set; }
        public string Link { get; set; } = null!;
        [EnumDataType(typeof(ServiceImageStatus))]
        public ServiceImageStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
