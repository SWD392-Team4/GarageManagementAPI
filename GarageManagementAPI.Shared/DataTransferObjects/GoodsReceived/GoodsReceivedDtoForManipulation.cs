

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsReceived
{
    public record class GoodsReceivedDtoForManipulation
    {

        public Guid SupplierContactId { get; set; }

        public Guid WarehouseId { get; set; }

        public string RefereneceNumber { get; set; } = null!;

        public string InvoiceCode { get; set; } = null!;

        public string SourceAddress { get; set; } = null!;

        public string SourceProvince { get; set; } = null!;

        public string SourceDistrict { get; set; } = null!;

        public string SourceWards { get; set; } = null!;

    }
}
