using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class CarPartMappingProfile : Profile
    {
        public CarPartMappingProfile()
        {
            CreateMap<CarPart, CarPartDto>();
            CreateMap<CarPartDtoForCreation, CarPart>();
            CreateMap<CarPartDtoForUpdate, CarPart>().ReverseMap();
            CreateMap<CarPartDtoForManipulation, CarPart>();
        }
    }
}
