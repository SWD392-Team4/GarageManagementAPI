namespace GarageManagementAPI.Entities.Models
{
    public class ProductForCarModel : BaseEntity<ProductForCarModel>
    {
        public Guid CarModelId { get; set; }

        public Guid ProductId { get; set; }

        public CarModel? CarModel { get; set; }

        public Product? Product { get; set; }
    }
}