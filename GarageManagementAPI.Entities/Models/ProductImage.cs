namespace GarageManagementAPI.Entities.Models
{
    public class ProductImage : BaseEntity<ProductImage>
    {
        public required Guid ProductId { get; set; }

        public required string Link { get; set; }

        public Product? Product { get; set; }
    }
}