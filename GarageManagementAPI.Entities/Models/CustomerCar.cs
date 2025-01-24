namespace GarageManagementAPI.Entities.Models
{
    public class CustomerCar : BaseEntity<CustomerCar>
    {
        public Guid CarModelId { get; set; }

        public Guid CustomerId { get; set; }

        public required string LicensePlateNumber { get; set; }

        public required string VehicleIdentificationNumber { get; set; }

        public required string EngineNumber { get; set; }

        public required string Color { get; set; }

        public required string FuelType { get; set; }

        public required int Mileage { get; set; }

        public required DateOnly RegistraionDate { get; set; }

        public User? Customer { get; set; }

        public CarModel? CarModel { get; set; }
    }
}