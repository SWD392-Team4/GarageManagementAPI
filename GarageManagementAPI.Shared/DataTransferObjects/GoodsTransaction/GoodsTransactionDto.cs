namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsTransaction
{
    public record class GoodsTransactionDto : BaseDto<GoodsTransactionDto>
    {
        public Guid GoodsIssuedDetailId { get; set; }
        public Guid GoodsReceivedId { get; set; }
    }
}
