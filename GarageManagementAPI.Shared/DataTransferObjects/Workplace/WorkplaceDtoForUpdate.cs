using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.Workplace
{
    public record WorkplaceDtoForUpdate : WorkplaceDtoForManipulation
    {
        [EnumDataType(typeof(WorkplaceStatus))]
        public WorkplaceStatus Status { get; set; }
    }
}
