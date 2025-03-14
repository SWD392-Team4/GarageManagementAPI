

using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived
{
    public record class GoodsReceivedDto : BaseDto<GoodsReceivedDto>
    {
        public Guid Id { get; set; }
        public Guid CreatedWarehouseManagerId { get; set; }
        public string? UserName { get; set; }
        public Guid SupplierContactId { get; set; }
        public string? ContactPersonName { get; set; }
        public Guid WarehouseId { get; set; }
        public string? Warehouse { get; set; }
        public string RefereneceNumber { get; set; } = null!;
        public string InvoiceCode { get; set; } = null!;
        public string SourceAddress { get; set; } = null!;
        public string SourceProvince { get; set; } = null!;
        public string SourceDistrict { get; set; } = null!;
        public string SourceWards { get; set; } = null!;
        public decimal TotalPrice { get; set; }

        [EnumDataType(typeof(GoodsReceivedStatus))]
        public GoodsReceivedStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
