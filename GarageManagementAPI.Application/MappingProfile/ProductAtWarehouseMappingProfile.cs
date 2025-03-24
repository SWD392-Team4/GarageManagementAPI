using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtWarehouse;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductAtWarehouseMappingProfile : Profile
    {
        public ProductAtWarehouseMappingProfile() {
            CreateMap<ProductAtWarehouse, ProductAtWarehouseDto>()
                .ForMember(dest => dest.ProductName, otps =>
                {
                    otps.PreCondition(otp => otp.GoodsReceivedDetail.Product != null);
                    otps.MapFrom(src => src.GoodsReceivedDetail.Product.ProductName);
                })
                 .ForMember(dest => dest.ProductStatus, otps =>
                 {
                     otps.PreCondition(otp => otp.GoodsReceivedDetail.Product != null);
                     otps.MapFrom(src => src.GoodsReceivedDetail.Product.Status);
                 })
                 .ForMember(dest => dest.ProductId, otps =>
                  {
                      otps.PreCondition(otp => otp.GoodsReceivedDetail.Product != null);
                      otps.MapFrom(src => src.GoodsReceivedDetail.Product.Id);
                  })
                .ForMember(dest => dest.ProductPrice, otps =>
                {
                    otps.PreCondition(otp => otp.GoodsReceivedDetail.Product != null);
                    otps.MapFrom(src => src.GoodsReceivedDetail.Product.ProductPrice);
                })
                .ForMember(dest => dest.ProductImage, otps =>
                {
                    otps.PreCondition(otp => otp.GoodsReceivedDetail.Product.ProductImages != null);
                    otps.MapFrom(src => src.GoodsReceivedDetail.Product.ProductImages.Select(img => img.ImageLink).ToList());
                })
                .ForMember(dest => dest.BrandName, otps =>
                {
                    otps.PreCondition(otp => otp.GoodsReceivedDetail.Product.Brand != null);
                    otps.MapFrom(src => src.GoodsReceivedDetail.Product.Brand.BrandName);
                })
                .ForMember(dest => dest.ProductCategoryName, otps =>
                {
                    otps.PreCondition(otp => otp.GoodsReceivedDetail.Product.ProductCategory != null);
                    otps.MapFrom(src => src.GoodsReceivedDetail.Product.ProductCategory.Category);
                }); 
            CreateMap<ProductAtWarehouseDtoForManipulation, ProductAtWarehouse>();
            CreateMap<ProductAtWarehouseDtoForCreation, ProductAtWarehouse>();
            CreateMap<ProductAtWarehouseDtoForUpdate, ProductAtWarehouse>();
        }
    }
}
