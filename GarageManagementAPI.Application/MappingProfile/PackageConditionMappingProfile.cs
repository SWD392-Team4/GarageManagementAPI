using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.PackageCondition;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class PackageConditionMappingProfile : Profile
    {
        public PackageConditionMappingProfile()
        {
            CreateMap<PackageConditionDtoForCreation, PackageCondition>();
            CreateMap<PackageConditionDtoForUpdate, PackageCondition>();
            CreateMap<PackageCondition, PackageConditionDto>();
        }
    }
}
