namespace GarageManagementAPI.Entities.Models
{
    public class CarCategory : BaseEntity<CarCategory>
    {
        public required string Category { get; set; }

        public required string Description { get; set; }

        public ICollection<ServiceHistory>? ServiceHistories { get; set; }

        public ICollection<PackageHistory>? PackageHistories { get; set; }

        public ICollection<CarModel>? CarModels { get; set; }
    }
}