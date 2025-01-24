namespace GarageManagementAPI.Entities.Models
{
    public class CarPart : BaseEntity<CarPart>
    {
        public Guid CarPartCategoryId { get; set; }

        public required string Name { get; set; }

        public CarPartCategory? CarPartCategory { get; set; }

        public ICollection<ProductCarPart>? ProductCarParts { get; set; }
    }
}