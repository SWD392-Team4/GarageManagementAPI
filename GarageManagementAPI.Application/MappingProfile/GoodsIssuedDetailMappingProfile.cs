using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsIssuedDetailMappingProfile : Profile
    {
        public GoodsIssuedDetailMappingProfile()
        {
            CreateMap<GoodsIssuedDetail, GoodsIssuedDetailDto>();
            CreateMap<GoodsIssuedDetailDtoForCreation, GoodsIssuedDetail>();
            CreateMap<GoodsIssuedDetailDtoForUpdate, GoodsIssuedDetail>().ReverseMap();
            CreateMap<GoodsIssuedDetailDtoForManipulation, GoodsIssuedDetail>();
        }
    }
}
