using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class Service : BaseEntity<Service>
    {
        public Guid CarPartId { get; set; }

        public Guid CarCategoryId { get; set; }

        public string ServiceCategory { get; set; } = null!;

        public string WorkNature { get; set; } = null!;

        public string Action { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int EstimatedHours { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual CarCategory CarCategory { get; set; } = null!;

        public virtual CarPart CarPart { get; set; } = null!;

        public virtual ICollection<PackageDetail> PackageDetails { get; set; } = new List<PackageDetail>();

        public virtual ICollection<ServiceFeedBack> ServiceFeedBacks { get; set; } = new List<ServiceFeedBack>();

        public virtual ICollection<ServiceHistory> ServiceHistories { get; set; } = new List<ServiceHistory>();

        public virtual ServiceImage? ServiceImage { get; set; }
    }

}

