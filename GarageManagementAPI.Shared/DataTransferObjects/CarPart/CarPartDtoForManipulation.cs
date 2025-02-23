namespace GarageManagementAPI.Shared.DataTransferObjects.CarPart
{
    public record class CarPartDtoForManipulation
    {
        public Guid CarPartCategoryId { get; set; }
        public string PartName { get; set; } = null!;
    }
}
