namespace GarageManagementAPI.Entities.Models
{
    public class Product : BaseEntity<Product>
    {
        public Guid ProductCategoryId { get; set; }

        public Guid BrandId { get; set; }

        public required string Name { get; set; }

        public required string Barcode { get; set; }

        public required string Description { get; set; }

        public ProductCategory? ProductCategory { get; set; }

        public Brand? Brand { get; set; }

        public ICollection<ProductImage>? ProductImages { get; set; }

        public ICollection<ProductCarPart>? ProductCarParts { get; set; }

        public ICollection<ProductForCarModel>? ProductForCarModels { get; set; }

        public ICollection<ProductHistory>? ProductHistorys { get; set; }

        public ICollection<ProductAtStore>? ProductAtStores { get; set; }

        public ICollection<ProductAtWareHouse>? ProductAtWareHouses { get; set; }
    }
}