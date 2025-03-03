using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.ProductHistory
{
    //record: đại diện cho các đối tượng bất biến (immutable)
    public record ProductHistoryDtoForManipulation
    {
        public decimal ProductPrice { get; set; }

    }
}
