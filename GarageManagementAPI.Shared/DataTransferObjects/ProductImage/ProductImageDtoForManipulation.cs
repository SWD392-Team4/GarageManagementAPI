namespace GarageManagementAPI.Shared.DataTransferObjects.ProductImage
{
    public record class ProductImageDtoForManipulation
    {
        public Guid ProductId { get; set; }

        public string Link { get; set; } = null!;
    }
}
