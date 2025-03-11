namespace GarageManagementAPI.Entities.Models
{
    public partial class GoodsTransaction : BaseEntity<GoodsTransaction>
    {
        public Guid GoodsIssuedDetailId { get; set; }
        public Guid GoodsReceivedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public virtual GoodsReceived GoodsReceived { get; set; } = null!;
        public virtual GoodsIssuedDetail GoodsIssuedDetail { get; set; } = null!;
    }
}
