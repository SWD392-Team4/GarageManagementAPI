using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Product;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                 .ForMember(dest => dest.BrandName, opts =>
                 {
                     opts.PreCondition(src => src.Brand != null);
                     opts.MapFrom(src => src.Brand!.BrandName);
                 })
                 .ForMember(dest => dest.BrandImage, opts =>
                 {
                     opts.PreCondition(src => src.Brand != null);
                     opts.MapFrom(src => src.Brand!.ImageLink);
                 })
                   .ForMember(dest => dest.ProductCategoryName, opts =>
                   {
                       opts.PreCondition(src => src.ProductCategory != null);
                       opts.MapFrom(src => src.ProductCategory!.Category);
                   })
                 .ForMember(dest => dest.ProductImage, otp =>
                 {
                     otp.PreCondition(src => src.ProductImages != null && src.ProductImages.Any());
                     otp.MapFrom(src => src.ProductImages.Select(e => e.ImageLink).ToList());
                 })
                 .ForMember(dest => dest.CarModels, opt => opt.MapFrom(src => src.CarModels))
                 .ForMember(dest => dest.CarParts, opt => opt.MapFrom(src => src.CarParts));

            CreateMap<ProductDtoForCreation, Product>();

            CreateMap<ProductDtoForUpdate, Product>().ReverseMap()
               .ForAllMembers(opt =>
               {
                   opt.Condition((src, dest, srcMember) => srcMember != null);
               });
        }
    }
}
