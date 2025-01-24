namespace GarageManagementAPI.Entities.Models
{
    public class CarPartCategory : BaseEntity<CarPartCategory>
    {
        public required string Name { get; set; }

        public ICollection<CarPart>? CarParts { get; set; }
    }
}