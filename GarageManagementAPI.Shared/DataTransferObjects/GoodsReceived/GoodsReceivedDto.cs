

using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived
{
    public record class GoodsReceivedDto : BaseDto<GoodsReceivedDto>
    {
        public Guid Id { get; set; }
        public string RefereneceNumber { get; set; } = null!;
        public string InvoiceCode { get; set; } = null!;
        public string SourceAddress { get; set; } = null!;
        public string SourceProvince { get; set; } = null!;
        public string SourceDistrict { get; set; } = null!;
        public string SourceWards { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public string ContactPersonName { get; set; } = null!;
        public string WorkPlaceName { get; set; } = null!;
        public string WarehouseManagereName { get; set; } = null!;

        [EnumDataType(typeof(GoodsReceivedStatus))]
        public GoodsReceivedStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
