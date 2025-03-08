using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class GoodsIssuedDetailParameters : RequestParameters
    {
        public GoodsIssuedDetailParameters() => OrderBy = "Quantity";
        public int minQuantity { get; set; } = 0;
        public int? maxQuantity { get; set; } = null!;
        [EnumDataType(typeof(GoodsIssuedDetailStatus))]
        public GoodsIssuedDetailStatus? Status { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
