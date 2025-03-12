using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsIssuedDetailProfile : Profile
    {
        public GoodsIssuedDetailProfile()
        {
            CreateMap<GoodsIssuedDetail, GoodsIssuedDetailDto>();
            CreateMap<GoodsIssuedDetailDtoForCreation, GoodsIssuedDetail>();
            CreateMap<GoodsIssuedDetailDtoForUpdate, GoodsIssuedDetail>().ReverseMap();
            CreateMap<GoodsIssuedDetailDtoForManipulation, GoodsIssuedDetail>();
        }
    }
}
