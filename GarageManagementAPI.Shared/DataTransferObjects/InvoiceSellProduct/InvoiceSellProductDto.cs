using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct
{
    public record class InvoiceSellProductDto : BaseDto<InvoiceSellProductDto>
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
}
