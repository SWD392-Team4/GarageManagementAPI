using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class PackageImage : BaseEntity<PackageImage>
    {
        public Guid PackageId { get; set; }
        public string? ImageLink { get; set; }
        public string? ImageId { get; set; }
        public virtual Package Package { get; set; } = null!;
    }
}

