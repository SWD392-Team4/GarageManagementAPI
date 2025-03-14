using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsIssuedMappingProfile : Profile
    {
        public GoodsIssuedMappingProfile()
        {
            CreateMap<GoodsIssued, GoodsIssuedDto>()
                .ForMember(dest => dest.UserName, otps =>
                {
                    otps.PreCondition(src => src.CreatedWareHouseManager != null);
                    otps.MapFrom(src => src.CreatedWareHouseManager!.LastName + " " + src.CreatedWareHouseManager!.FirstName);
                })
                .ForMember(dest => dest.WarehouseName, otps =>
                {
                    otps.PreCondition(src => src.Warehouse != null);
                    otps.MapFrom(src => src.Warehouse!.Name);
                })
                .ForMember(dest => dest.GarageName, otps =>
                {
                    otps.PreCondition(src => src.Garage != null);
                    otps.MapFrom(src => src.Garage!.Name);
                });
            CreateMap<GoodsIssuedDtoForCreation, GoodsIssued>();
            CreateMap<GoodsIssuedDtoForUpdate, GoodsIssued>().ReverseMap();
            CreateMap<GoodsIssuedDtoForManipulation, GoodsIssued>();
        }
    }
}
