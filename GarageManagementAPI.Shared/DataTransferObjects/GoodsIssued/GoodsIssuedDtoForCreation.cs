using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;

namespace GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued
{
    public record class GoodsIssuedDtoForCreation : GoodsIssuedDtoForManipulation
    {
        public List<GoodsIssuedDetailDtoForCreation> gooodsIssuedDetails { get; set; } = new List<GoodsIssuedDetailDtoForCreation>(); 
    }
}
