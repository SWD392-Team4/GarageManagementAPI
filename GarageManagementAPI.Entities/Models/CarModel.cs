namespace GarageManagementAPI.Entities.Models
{
    public class CarModel : BaseEntity<CarModel>
    {
        public Guid BrandId { get; set; }

        public Guid CarCategoryId { get; set; }

        public required string Name { get; set; }

        public required string ModelYear { get; set; }

        public Brand? Brand { get; set; }

        public CarCategory? CarCategory { get; set; }

        public ICollection<CustomerCar>? CustomerCars { get; set; }

        public ICollection<ProductForCarModel>? ProductForCarModels { get; set; }
    }
}