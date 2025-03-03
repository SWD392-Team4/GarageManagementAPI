using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Entities.Models
{
    public partial class ServiceImage : BaseEntity<ServiceImage>
    {
        public Guid ServiceId { get; set; }
        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";
        [EnumDataType(typeof(ServiceImageStatus))]
        public ServiceImageStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public virtual Service IdNavigation { get; set; } = null!;
    }

}

