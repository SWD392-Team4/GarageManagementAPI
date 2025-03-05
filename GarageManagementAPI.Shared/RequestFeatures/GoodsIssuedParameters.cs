using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.RequestFeatures
{
    public class GoodsIssuedParameters : RequestParameters
    {
        public GoodsIssuedParameters() => OrderBy = "TotalCost";
        public decimal? minTotalCost { get; set; } = 0;
        public decimal? maxTotalCost { get; set; }
        public string ReferenceNumber { get; set; } = null!;
        public string InvoiceCode { get; set; } = null!;

        [EnumDataType(typeof(GoodsIssuedStatus))]
        public GoodsIssuedStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
