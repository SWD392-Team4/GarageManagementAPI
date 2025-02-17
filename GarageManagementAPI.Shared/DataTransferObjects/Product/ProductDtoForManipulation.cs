using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    //record: đại diện cho các đối tượng bất biến (immutable)
    public record ProductDtoForManipulation
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductBarcode { get; set; }
        [Required]
        public string ProductDescription { get; set; } = null!;
        //public List<Guid> GoodsReceivedIds { get; set; } = new List<Guid>();
        public Guid ProductCategoryId { get; set; } 
        //public List<Guid> ProductImagesId { get; set; } = new List<Guid>();
        //public Guid ProductHistoriesId { get; set; }
        //public List<Guid> CarModelsId { get; set; } = new List<Guid>();
        //public List<Guid> CarPartsId { get; set; } = new List<Guid>();
        public Guid BrandId { get; set; }
    }
}
