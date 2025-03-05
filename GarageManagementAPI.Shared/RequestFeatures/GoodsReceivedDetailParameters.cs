using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class GoodsReceivedDetailParameters : RequestParameters
    {
        public GoodsReceivedDetailParameters() => OrderBy = "TotalPrice";
        public int? MinQuantity { get; set; } = 0;
        public int? MaxQuantity { get; set; }
        public decimal? MinUnitPrice { get; set; } = 0;
        public decimal? MaxUnitPrice { get; set; }
        public decimal? MiniTotalPrice { get; set; } = 0;
        public decimal? MaxTotalPrice { get; set; }

        [EnumDataType(typeof(GoodsReceivedDetailStatus))]
        public GoodsReceivedDetailStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
