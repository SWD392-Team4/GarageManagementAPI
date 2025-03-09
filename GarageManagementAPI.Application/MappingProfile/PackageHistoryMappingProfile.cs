using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Package;
using GarageManagementAPI.Shared.DataTransferObjects.PackageHistory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class PackageHistoryMappingProfile : Profile
    {
        public PackageHistoryMappingProfile()
        {
            CreateMap<PackageHistory, PackageHistoryDto>()
                .ForMember(dest => dest.Category, opts =>
            {
                opts.PreCondition(src => src.CarCategory != null);
                opts.MapFrom(src => src.CarCategory.Category);
            }); ;
        }
    }
}
