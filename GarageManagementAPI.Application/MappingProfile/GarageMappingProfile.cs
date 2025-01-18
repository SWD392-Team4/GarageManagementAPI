using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Employee;
using GarageManagementAPI.Shared.DataTransferObjects.Garage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class GarageMappingProfile : Profile
    {
        public GarageMappingProfile() 
        {
            CreateMap<Garage, GarageDto>();
            CreateMap<Garage, GarageDtoWithRelation>()
                .IncludeBase<Garage, GarageDto>()
                .ForMember(garageDto =>
                garageDto.Employees, opts =>
                    opts.Condition(
                        (src, dest, srcMember) =>
                        srcMember != null && srcMember.Any()
                    ));
            CreateMap<GarageForCreationDto, Garage>();
            CreateMap<GarageForUpdateDto, Garage>().ReverseMap();
        }
    }
}
