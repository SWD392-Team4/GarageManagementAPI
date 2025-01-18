using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile() 
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, EmployeeDtoWithRelation>()
                .IncludeBase<Employee, EmployeeDto>()
                .ForMember(employeeDto =>
                employeeDto.Garage, opts =>
                    opts.Condition(
                        (src, dest, srcMember) =>
                        srcMember != null 
                    )); ;
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
        }
    }
}
