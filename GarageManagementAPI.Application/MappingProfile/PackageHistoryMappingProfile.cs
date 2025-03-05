using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.PackageHistory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class PackageHistoryMappingProfile : Profile
    {
        public PackageHistoryMappingProfile()
        {
            CreateMap<PackageHistory, PackageHistoryDto>();
        }
    }
}
