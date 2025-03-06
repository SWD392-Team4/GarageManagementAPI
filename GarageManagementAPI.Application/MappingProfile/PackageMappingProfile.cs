using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Package;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class PackageMappingProfile : Profile
    {
        public PackageMappingProfile()
        {
            CreateMap<PackageDtoForCreation, Package>();
            CreateMap<PackageDtoForCreation, PackageHistory>();
            CreateMap<PackageDtoForUpdate, PackageHistory>();
            CreateMap<PackageDtoForUpdate, Package>();
            CreateMap<PackageHistory, PackageDto>();
            //CreateMap<Package, PackageDto>()
            //    .ForMember(dest => dest.Category, opts =>
            //    {
            //        opts.PreCondition(src => src.CarCategory != null);
            //        opts.MapFrom(src => src.CarCategory.Category);
            //    })
            //    .ForMember(dest => dest.ImageLinks, opts =>
            //    {
            //        opts.PreCondition(src => src.PackageImages != null);
            //        opts.MapFrom(src => src.PackageImages.Select(image => image.ImageLink));
            //    })
            //    .ForMember(dest => dest.PackagePrice, opts =>
            //    {
            //        opts.PreCondition(src => src.PackageHistories != null && src.PackageHistories.Any());
            //        opts.MapFrom(src => src.PackageHistories.OrderByDescending(ph => ph.CreatedAt).First().PackagePrice);
            //    })
            //    .ForMember(dest => dest.ValidityPeriod, opts =>
            //    {
            //        opts.PreCondition(src => src.PackageHistories != null && src.PackageHistories.Any());
            //        opts.MapFrom(src => src.PackageHistories.OrderByDescending(ph => ph.CreatedAt).First().ValidityPeriod);
            //    })
            //    .ForMember(dest => dest.TimeUnit, opts =>
            //    {
            //        opts.PreCondition(src => src.PackageHistories != null && src.PackageHistories.Any());
            //        opts.MapFrom(src => src.PackageHistories.OrderByDescending(ph => ph.CreatedAt).First().TimeUnit);
            //    })
            //    .ForMember(dest => dest.UsageLimit, opts =>
            //    {
            //        opts.PreCondition(src => src.PackageHistories != null && src.PackageHistories.Any());
            //        opts.MapFrom(src => src.PackageHistories.OrderByDescending(ph => ph.CreatedAt).First().UsageLimit);
            //    });

        }
    }
}
