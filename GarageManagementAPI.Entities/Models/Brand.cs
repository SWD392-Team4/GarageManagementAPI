using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class Brand : BaseEntity<Brand>
    {
        public string BrandName { get; set; } = null!;

        public string LogoLink { get; set; } = null!;

        public string LogoId { get; set; } = null!;

        [EnumDataType(typeof(BrandStatus))]
        public BrandStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }

}

