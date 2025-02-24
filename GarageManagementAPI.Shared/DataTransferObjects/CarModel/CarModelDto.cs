namespace GarageManagementAPI.Shared.DataTransferObjects.CarModel
{
    public record CarModelDto
    {
        public Guid Id { get; set; }

        public Guid CarCategoryId { get; set; }

        public Guid BrandId { get; set; }

        public string? BrandName { get; set; }

        public string? BrandLinkLogo { get; set; }

        public string? Category { get; set; }

        public string? ModelName { get; set; }

        public string? ModelYear { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
