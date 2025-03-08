using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

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
            CreateMap<Package, PackageDto>()
                .ForMember(dest => dest.Category, opts =>
                {
                    opts.PreCondition(src => src.CarCategory != null);
                    opts.MapFrom(src => src.CarCategory.Category);
                })
                .ForMember(dest => dest.PackagePrice, opts =>
                {
                    opts.PreCondition(src => src.PackageHistories.Count > 0 && src.PackageHistories.OrderByDescending(e => e.CreatedAt).First().Status.Equals(PackageHistoryStatus.Active));
                    opts.MapFrom(src => src.PackageHistories.First().PackagePrice);
                })
                .ForMember(dest => dest.UsageLimit, opts =>
                {
                    opts.PreCondition(src => src.PackageHistories.Count > 0 && src.PackageHistories.OrderByDescending(e => e.CreatedAt).First().Status.Equals(PackageHistoryStatus.Active));
                    opts.MapFrom(src => src.PackageHistories.First().UsageLimit);
                })
                .ForMember(dest => dest.ValidityPeriod, opts =>
                {
                    opts.PreCondition(src => src.PackageHistories.Count > 0 && src.PackageHistories.OrderByDescending(e => e.CreatedAt).First().Status.Equals(PackageHistoryStatus.Active));
                    opts.MapFrom(src => src.PackageHistories.First().ValidityPeriod);
                })
                .ForMember(dest => dest.TimeUnit, opts =>
                {
                    opts.PreCondition(src => src.PackageHistories.Count > 0 && src.PackageHistories.OrderByDescending(e => e.CreatedAt).First().Status.Equals(PackageHistoryStatus.Active));
                    opts.MapFrom(src => src.PackageHistories.First().TimeUnit);
                }).ForMember(dest => dest.Status, opts =>
                {
                    opts.PreCondition(src => src.PackageHistories.Count > 0);
                    opts.MapFrom(src => src.PackageHistories.First().Status);
                });
        }
    }
}
