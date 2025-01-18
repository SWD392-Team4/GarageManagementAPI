using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;

namespace GarageManagementAPI.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Garage, GarageDto>()
                .ForMember(garageDto =>
                garageDto.Employees, opts =>
                    opts.Condition(
                        (src, dest, srcMember) =>
                        srcMember != null && srcMember.Any()));
            CreateMap<GarageForCreationDto, Garage>();
            CreateMap<GarageForUpdateDto, Garage>().ReverseMap();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        }
    }
}
