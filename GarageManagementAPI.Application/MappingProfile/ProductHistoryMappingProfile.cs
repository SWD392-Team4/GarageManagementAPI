using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductHistoryMappingProfile : Profile
    {
       public ProductHistoryMappingProfile() {
            CreateMap<ProductHistory, ProductHistoryDto>();
            CreateMap<ProductHistoryDtoForCreation, ProductHistory>();
            CreateMap<ProductHistoryDtoForUpdate, ProductHistory>().ReverseMap();
            CreateMap<ProductHistoryDtoForManipulation, ProductHistory>();
        }
    }
}
