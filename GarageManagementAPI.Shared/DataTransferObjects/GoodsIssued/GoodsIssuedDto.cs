using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued
{
    public record class GoodsIssuedDto : BaseDto<GoodsIssuedDto>
    {
        public Guid Id { get; set; }
        public decimal TotalCost { get; set; }
        public string ReferenceNumber { get; set; } = null!;
        public string InvoiceCode { get; set; } = null!;
        [EnumDataType(typeof(GoodsIssuedStatus))]
        public GoodsIssuedStatus Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

    }
}
