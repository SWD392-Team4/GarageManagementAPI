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
            CreateMap<Garage, GarageDto>();
            CreateMap<GarageForCreationDto, Garage>();
            CreateMap<GarageForUpdateDto, Garage>().ReverseMap();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();

        }
    }
}
