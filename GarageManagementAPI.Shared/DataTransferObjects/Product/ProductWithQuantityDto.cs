using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public class ProductWithQuantityDto
    {
        public required Guid Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductBarcode { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid BrandId { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        [EnumDataType(typeof(ProductStatus))]
        public ProductStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public int TotalQuantity { get; set; } 
    }
}
