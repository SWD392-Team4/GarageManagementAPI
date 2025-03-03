using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.SupplierContact
{
    public record class SupplierContactDtoForUpdate : SupplierContactDtoForManipulation
    {

        [EnumDataType(typeof(SupplierContactStatus))]
        public SupplierContactStatus Status { get; set; }
    }
}
