namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued
{
    public record class GoodsIssuedDtoForManipulation
    {
        public Guid WarehouseId { get; set; }
        public Guid GarageId { get; set; }

    }
}
