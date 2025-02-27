using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductImageMappingProfile : Profile
    {
        public ProductImageMappingProfile()
        {
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageDtoForCreation, ProductImage>();
            CreateMap<ProductImageDtoForUpdate, ProductImage>().ReverseMap();
            CreateMap<ProductImageDtoForManipulation, ProductImage>();
        }
    }
}
