using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsTransaction
{
    public record class GoodsTransactionDtoForManipulation
    {
        public Guid GoodsIssuedDetailId { get; set; }
        public Guid GoodsReceivedId { get; set; }
    }
}
