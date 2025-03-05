using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.GoodsIssued;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GoodsIssuedMappingProfile : Profile
    {
        public GoodsIssuedMappingProfile()
        {
            CreateMap<GoodsIssued, GoodsIssuedDto>();
            CreateMap<GoodsIssuedDtoForCreation, GoodsIssued>();
            CreateMap<GoodsIssuedDtoForUpdate, GoodsIssued>().ReverseMap();
            CreateMap<GoodsIssuedDtoForManipulation, GoodsIssued>();
        }
    }
}
