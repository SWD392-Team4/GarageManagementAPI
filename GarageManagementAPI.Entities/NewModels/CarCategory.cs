using GarageManagementAPI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.NewModels
{
    public partial class CarCategory : BaseEntity<CarCategory>
    {
        public required string Category { get; set; }

        public required string Description { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();

        public virtual ICollection<Package> Packages { get; set; } = new List<Package>();

        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }

}

