using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Brand;
using GarageManagementAPI.Shared.DataTransferObjects.User;
using GarageManagementAPI.Shared.DataTransferObjects.Workplace;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class BrandMappingProfile : Profile
    {
       public BrandMappingProfile() {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDtoForCreation, Brand>();
            CreateMap<BrandDtoForUpdate, Brand>().ReverseMap();
            CreateMap<BrandDtoForManipulation, Brand>();
        }
    }
}
