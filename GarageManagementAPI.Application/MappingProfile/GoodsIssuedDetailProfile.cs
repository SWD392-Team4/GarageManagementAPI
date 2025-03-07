using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssuedDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsIssuedDetailProfile : Profile
    {
        public GoodsIssuedDetailProfile()
        {
            CreateMap<GoodsIssuedDetail, GoodsIssuedDetailDto>()
                 .ForMember(dest => dest.ReferenceNumberGoodIssued, opts =>
                 {

                     opts.PreCondition(src => src.GoodsIssued != null);
                     opts.MapFrom(src => src.GoodsIssued.ReferenceNumber);
                 })
                  .ForMember(dest => dest.ProductAtGarageID, opts =>
                  {
                      opts.PreCondition(src => src.ProductAtGarage != null);
                      opts.MapFrom(src => src.ProductAtGarage.Id);
                  })
                  .ForMember(dest => dest.ProductAtWareHouseId, opts =>
                  {
                      opts.PreCondition(src => src.ProductAtWareHouse != null);
                      opts.MapFrom(src => src.ProductAtWareHouse.Id);
                  });
            CreateMap<GoodsIssuedDetailDtoForCreation, GoodsIssuedDetail>();
            CreateMap<GoodsIssuedDetailDtoForUpdate, GoodsIssuedDetail>().ReverseMap();
            CreateMap<GoodsIssuedDetailDtoForManipulation, GoodsIssuedDetail>();
        }
    }
}
