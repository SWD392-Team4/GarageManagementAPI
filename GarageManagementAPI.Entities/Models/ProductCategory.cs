namespace GarageManagementAPI.Entities.Models
{
    public class ProductCategory : BaseEntity<ProductCategory>
    {
        public required string ProdcutCategory { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}