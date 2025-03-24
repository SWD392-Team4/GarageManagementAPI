using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsIssuedDetailMappingProfile : Profile
    {
        public GoodsIssuedDetailMappingProfile()
        {
            CreateMap<GoodsIssuedDetail, GoodsIssuedDetailDto>()
                .ForMember(dest => dest.ProductName, otps =>
                {
                    otps.PreCondition(otp => otp.ProductAtGarage!.Product != null);
                    otps.MapFrom(otp => otp.ProductAtGarage!.Product.ProductName);
                });
            CreateMap<GoodsIssuedDetailDtoForCreation, GoodsIssuedDetail>();
            CreateMap<GoodsIssuedDetailDtoForUpdate, GoodsIssuedDetail>().ReverseMap();
            CreateMap<GoodsIssuedDetailDtoForManipulation, GoodsIssuedDetail>();
        }
    }
}
