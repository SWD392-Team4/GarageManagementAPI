using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductAtGarageMappingProfile : Profile
    {
        public ProductAtGarageMappingProfile()
        {
            CreateMap<ProductAtGarage, ProductAtGarageDto>()              
                .ForMember(dest => dest.ProductName, otps =>
                {
                    otps.PreCondition(otp => otp.Product != null);
                    otps.MapFrom(src => src.Product.ProductName);
                })
                .ForMember(dest => dest.ProductDescription, otps =>
                {
                    otps.PreCondition(otp => otp.Product != null);
                    otps.MapFrom(src => src.Product.ProductDescription);
                })
                 .ForMember(dest => dest.ProductStatus, otps =>
                 {
                     otps.PreCondition(otp => otp.Product != null);
                     otps.MapFrom(src => src.Product.Status);
                 })
                .ForMember(dest => dest.ProductPrice, otps =>
                {
                    otps.PreCondition(otp => otp.Product != null);
                    otps.MapFrom(src => src.Product.ProductPrice);
                })
                .ForMember(dest => dest.ProductImage, otps =>
                {
                    otps.PreCondition(otp => otp.Product != null);
                    otps.MapFrom(src => src.Product.ProductImages.Select(img => img.ImageLink).ToList());
                })
                .ForMember(dest => dest.BrandName, otps =>
                {
                    otps.PreCondition(otp => otp.Product != null);
                    otps.MapFrom(src => src.Product.Brand.BrandName);
                })
                .ForMember(dest => dest.ProductCategoryName, otps =>
                {
                    otps.PreCondition(otp => otp.Product != null);
                    otps.MapFrom(src => src.Product.ProductCategory.Category);
                });
            CreateMap<ProductAtGarageForCreation, ProductAtGarage>();
        }
    }
}
