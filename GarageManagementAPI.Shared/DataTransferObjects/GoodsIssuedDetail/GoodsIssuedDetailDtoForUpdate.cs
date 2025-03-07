using GarageManagementAPI.Shared.Enums.SystemStatuss;
using System.ComponentModel.DataAnnotations;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail
{
    public record class GoodsIssuedDetailDtoForUpdate
    {

        [EnumDataType(typeof(GoodsIssuedDetailStatus))]
        public GoodsIssuedDetailStatus Status { get; set; }

    }
}
