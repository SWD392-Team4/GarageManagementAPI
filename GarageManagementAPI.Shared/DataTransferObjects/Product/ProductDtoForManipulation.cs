using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    //record: đại diện cho các đối tượng bất biến (immutable)
    public record ProductDtoForManipulation
    {
        public required string ProductName { get; set; }
        public required string ProductBarcode { get; set; }
        public string ProductDescription { get; set; } = null!;
        public Guid ProductCategoryId { get; set; } 
        public Guid BrandId { get; set; }
        public string? Link { get; set; } = null!;
        public required decimal ProductPrice { get; set; }
    }
}
