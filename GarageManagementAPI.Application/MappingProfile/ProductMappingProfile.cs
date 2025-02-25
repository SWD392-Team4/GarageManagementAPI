﻿using AutoMapper;
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
                   .ForMember(dest => dest.Category, opts =>
                   {
                       opts.PreCondition(src => src.ProductCategory != null);
                       opts.MapFrom(src => src.ProductCategory!.Category);
                   })
                 .ForMember(dest => dest.ImageLink, otp =>
                 {
                     otp.PreCondition(src => src.ProductImages != null && src.ProductImages.Any());
                     otp.MapFrom(src => src.ProductImages.Select(e => e.ImageLink).ToList());
                 })
                .ForMember(dest => dest.ProductPrice, opt =>
                {
                    //Any() checks whether there is at least one item in the ProductHistories collection of the src object. Specifically, it returns a boolean value (true or false): LINQ 
                    opt.PreCondition(src => src.ProductHistories != null && src.ProductHistories.Any());
                    opt.MapFrom(src => src.ProductHistories
                        .OrderByDescending(h => h.CreatedAt)
                        .First()
                        .ProductPrice
                    );
                });


            CreateMap<ProductDtoForCreation, Product>();

            CreateMap<ProductDtoForUpdate, Product>().ReverseMap()
               .ForAllMembers(opt =>
               {
                   opt.Condition((src, dest, srcMember) => srcMember != null);
               });
        }
    }
}
