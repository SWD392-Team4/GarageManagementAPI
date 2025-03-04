using System.ComponentModel.DataAnnotations;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued
{
    public record class GoodsIssuedDtoForUpdate
    {
        [EnumDataType(typeof(GoodsIssuedStatus))]
        public GoodsIssuedStatus Status { get; set; }
    }
}
