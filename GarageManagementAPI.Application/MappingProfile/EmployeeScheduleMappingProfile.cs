using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.EmployeeSchedule;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class EmployeeScheduleMappingProfile : Profile
    {
        public EmployeeScheduleMappingProfile()
        {
            CreateMap<EmployeeSchedule, EmployeeScheduleDtoWithRelation>();
        }
    }
}
