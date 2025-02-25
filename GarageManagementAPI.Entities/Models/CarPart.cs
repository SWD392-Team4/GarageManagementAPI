using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class CarPart : BaseEntity<CarPart>
    {
        public Guid CarPartCategoryId { get; set; }
        public string PartName { get; set; } = null!;
        [EnumDataType(typeof(CarPartStatus))]
        public CarPartStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        // Phương thức đồng bộ cho tất cả thay đổi
        public virtual CarPartCategory CarPartCategory { get; set; } = null!;
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}

