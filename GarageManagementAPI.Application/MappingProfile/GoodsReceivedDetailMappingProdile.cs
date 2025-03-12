using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsReceivedDetailDetailMappingProdile: Profile
    {
        public GoodsReceivedDetailDetailMappingProdile()
        {
            CreateMap<GoodsReceivedDetail, GoodsReceivedDetailDto>();            
            CreateMap<GoodsReceivedDetailDtoForCreation, GoodsReceivedDetail>();
            CreateMap<GoodsReceivedDetailDtoForUpdate, GoodsReceivedDetail>().ReverseMap();
            CreateMap<GoodsReceivedDetailDtoForManipulation, GoodsReceivedDetail>();
        }
    }
}
