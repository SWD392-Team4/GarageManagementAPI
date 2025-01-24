namespace GarageManagementAPI.Entities.Models
{
    public class ProductCarPart : BaseEntity<ProductCarPart>
    {
        public Guid CarPartId { get; set; }

        public Guid ProductId { get; set; }

        public CarPart? CarPart { get; set; }

        public Product? Product { get; set; }
    }
}