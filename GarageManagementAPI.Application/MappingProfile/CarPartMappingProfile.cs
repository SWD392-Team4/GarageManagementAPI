using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarPart;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class CarPartMappingProfile : Profile
    {
        public CarPartMappingProfile()
        {
            CreateMap<CarPart, CarPartDto>()
                .ForMember(dest => dest.PartCategory, otps =>
                {
                    otps.PreCondition(src => src.CarPartCategory != null);
                    otps.MapFrom(src => src.CarPartCategory!.PartCategory);
                });
            CreateMap<CarPartDtoForCreation, CarPart>();
            CreateMap<CarPartDtoForUpdate, CarPart>().ReverseMap();
            CreateMap<CarPartDtoForManipulation, CarPart>();
        }
    }
}
