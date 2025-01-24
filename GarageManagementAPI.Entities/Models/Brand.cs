namespace GarageManagementAPI.Entities.Models
{
    public class Brand : BaseEntity<Brand>
    {
        public required string Name { get; set; }

        public required string LinkLogo { get; set; }

        public ICollection<CarModel>? CarModels { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}