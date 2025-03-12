namespace GarageManagementAPI.Shared.DataTransferObjects.ProductHistory
{
    public record class ProductHistoryDto : BaseDto<ProductHistoryDto>
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
