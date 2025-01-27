using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class CustomerCar : BaseEntity<CustomerCar>
    {
        public Guid CarModelId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid CreatedByEmployeeId { get; set; }

        public string LicensePlateNumber { get; set; } = null!;

        public string VehicleIdentificationNumber { get; set; } = null!;

        public string EngineNumber { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public int Mileage { get; set; }

        public DateOnly RegistrationDate { get; set; }

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual CarModel CarModel { get; set; } = null!;

        public virtual User CreatedByEmployee { get; set; } = null!;

        public virtual User Customer { get; set; } = null!;

        public virtual ICollection<PackageUsage> PackageUsages { get; set; } = new List<PackageUsage>();
    }

}

