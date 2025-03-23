using GarageManagementAPI.Shared.DataTransferObjects.ReplacementPart;
using GarageManagementAPI.Shared.DataTransferObjects.Service;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;

namespace GarageManagementAPI.Shared.DataTransferObjects.InvoiceServiceDetail
{
    public class InvoiceServiceDetailDto
    {
        public Guid ServiceHistoryId { get; set; }

        public Guid InvoiceId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public virtual ICollection<ReplacementPartDto>? ReplacementParts { get; set; }

        public virtual ServiceHistoryDto? ServiceHistory { get; set; }

        public virtual ServiceDto? Service { get; set; }
    }

}
