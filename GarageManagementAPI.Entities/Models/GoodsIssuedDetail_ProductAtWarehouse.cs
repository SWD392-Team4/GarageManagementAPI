namespace GarageManagementAPI.Entities.Models
{
    public partial class GoodsIssuedDetail_ProductAtWarehouse : BaseEntity<GoodsIssuedDetail_ProductAtWarehouse>
    {
        public Guid GoodsIssuedDetailId { get; set; }
        public virtual GoodsIssuedDetail GoodsIssuedDetail { get; set; } = null!;

        public Guid ProductAtWarehouseId { get; set; }
        public virtual ProductAtWarehouse ProductAtWarehouse { get; set; } = null!;

        public int QuantityUsed { get; set; }
    }
}
