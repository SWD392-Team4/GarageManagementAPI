using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetailPackage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class AppointmentDetailPackageMappingProfile : Profile
    {
        public AppointmentDetailPackageMappingProfile()
        {
            CreateMap<AppointmentDetailPackage, AppointmentDetailPackageDto>()
                .ForMember(dest => dest.PackageName, opts =>
                {
                    opts.PreCondition(src => src.PackageHistory != null);
                    opts.MapFrom(src => src.PackageHistory.PackageName);
                })
                .ForMember(dest => dest.PackagePrice, opts =>
                {
                    opts.PreCondition(src => src.PackageHistory != null);
                    opts.MapFrom(src => src.PackageHistory.PackagePrice);
                }).ForMember(dest => dest.PackageId, opts =>
                {
                    opts.PreCondition(src => src.PackageHistory != null);
                    opts.MapFrom(src => src.PackageHistory.PackageId);
                });
        }
    }
}
