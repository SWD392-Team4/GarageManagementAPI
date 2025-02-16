using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class EmployeeInfoMappingProfile : Profile
    {
        public EmployeeInfoMappingProfile()
        {
            CreateMap<UserForRegistrationEmployeeDto, EmployeeInfo>();
        }
    }
}
