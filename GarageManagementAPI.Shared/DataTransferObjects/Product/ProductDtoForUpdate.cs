using GarageManagementAPI.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Product
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus Status { get; set; }
    }
}
