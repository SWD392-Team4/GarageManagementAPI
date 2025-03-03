using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class PackageImage : BaseEntity<PackageImage>
    {
        public Guid PackageId { get; set; }
        public string? ImageLink { get; set; } = "N/A";
        public string? ImageId { get; set; } = "N/A";

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual Package Package { get; set; } = null!;
    }

}

