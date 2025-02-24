namespace GarageManagementAPI.Shared.DataTransferObjects.CarModel
{
    public record CarModelDtoForManipulation
    {
        public Guid BrandId { get; set; }

        public Guid CarCategoryId { get; set; }

        public string ModelName { get; set; } = null!;

        public DateOnly ModelYear { get; set; }
    }
}
