using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class GoodsReceivedParameters : RequestParameters
    {
        public GoodsReceivedParameters() => OrderBy = "TotalPrice";
        public string RefereneceNumber { get; set; } = null!;

        public string InvoiceCode { get; set; } = null!;

        public string SourceAddress { get; set; } = null!;

        public string SourceProvince { get; set; } = null!;

        public string SourceDistrict { get; set; } = null!;

        public string SourceWards { get; set; } = null!;

        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; }

        [EnumDataType(typeof(GoodsReceivedStatus))]
        public GoodsReceivedStatus? Status { get; set; } = null;

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
