using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct
{
    public record class InvoiceSellProductDto
    {
        public Guid InvoiceId { get; set; }

        public Guid ProductAtGarageId { get; set; }

        public Guid ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

    }
}
