using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Product;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>()
           .ForMember(dest => dest.ProductInfo, opt =>
            {
         // Kiểm tra nếu Products không null và có ít nhất một sản phẩm
            opt.PreCondition(src => src.Products != null && src.Products.Any());
            opt.MapFrom(src => src.Products
            .Select(p => new ProductDto
            {
                 Id = p.Id,
                 ProductName = p.ProductName,  // Ánh xạ ProductName
                 ProductBarcode = p.ProductBarcode,
            })
             .ToList()  // Chuyển thành danh sách
         );
     });

            CreateMap<ProductCategoryDtoForCreation, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryDtoForUpdate, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryDtoForManipulation, ProductCategory>().ReverseMap();
        }
    }
}
