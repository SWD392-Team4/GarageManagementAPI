using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsReceivedDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsReceivedDetailDetailMappingProdile: Profile
    {
        public GoodsReceivedDetailDetailMappingProdile()
        {
            CreateMap<GoodsReceivedDetail, GoodsReceivedDetailDto>()
                 .ForMember(dest => dest.Productname, opts =>
                 {
                     opts.PreCondition(src => src.Product != null);
                     opts.MapFrom(src => src.Product!.ProductName);
                 })
                  .ForMember(dest => dest.RefereneceNumber, opts =>
                  {
                      opts.PreCondition(src => src.GoodsReceived != null);
                      opts.MapFrom(src => src.GoodsReceived!.RefereneceNumber);
                  });              
            CreateMap<GoodsReceivedDetailDtoForCreation, GoodsReceivedDetail>();
            CreateMap<GoodsReceivedDetailDtoForUpdate, GoodsReceivedDetail>().ReverseMap();
            CreateMap<GoodsReceivedDetailDtoForManipulation, GoodsReceivedDetail>();
        }
    }
}
