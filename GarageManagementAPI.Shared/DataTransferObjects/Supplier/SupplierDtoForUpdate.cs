using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.Supplier
{
    public record class SupplierDtoForUpdate : SupplierDtoForManipulation
    {
        [EnumDataType(typeof(SupplierStatus))]
        public SupplierStatus Status { get; set; }
    }
}
