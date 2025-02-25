using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class CarPartCategory : BaseEntity<CarPartCategory>
    {
        public string PartCategory { get; set; } = null!;

        [EnumDataType(typeof(CarPartCategoryStatus))]
        public CarPartCategoryStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<CarPart> CarParts { get; set; } = new List<CarPart>();
    }

}

