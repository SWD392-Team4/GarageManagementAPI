using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Entities.Models
{
    public partial class GoodsIssued : BaseEntity<GoodsIssued>
    {
        public Guid CreatedWareHouseManagerId { get; set; }

        public Guid WarehouseId { get; set; }

        public Guid GarageId { get; set; }

        public decimal TotalCost { get; set; }

        public string ReferenceNumber { get; set; } = null!;

        public string InvoiceCode { get; set; } = null!;

        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public virtual User CreatedWareHouseManager { get; set; } = null!;

        public virtual Workplace Garage { get; set; } = null!;

        public virtual ICollection<GoodsIssuedDetail> GoodsIssuedDetails { get; set; } = new List<GoodsIssuedDetail>();

        public virtual Workplace Warehouse { get; set; } = null!;
    }

}

