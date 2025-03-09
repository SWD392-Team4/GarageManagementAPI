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
            CreateMap<PackageDtoForUpdate, Package>();
            CreateMap<Package, PackageDto>()
                .ForMember(dest => dest.Category, opts =>
                {
                    opts.PreCondition(src => src.CarCategory != null);
                    opts.MapFrom(src => src.CarCategory.Category);
                });
            CreateMap<Package, PackageHistory>()
                .ForMember(dest => dest.PackageId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
