using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategoryDtoForCreation, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryDtoForUpdate, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryDtoForManipulation, ProductCategory>().ReverseMap();
        }
    }
}
