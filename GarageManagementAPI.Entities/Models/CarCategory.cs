using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class CarCategory : BaseEntity<CarCategory>
    {
        public required string Category { get; set; }
        public required string Description { get; set; }
        [EnumDataType(typeof(CarCategoryStatus))]
        public CarCategoryStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
        public virtual ICollection<Package> Packages { get; set; } = new List<Package>();
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }

}

