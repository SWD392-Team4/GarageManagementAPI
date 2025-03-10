using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarModel;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class CarModelMappingProfile : Profile
    {
        public CarModelMappingProfile()
        {
            CreateMap<CarModel, CarModelDto>()
                .ForMember(dest => dest.BrandName, opt =>
                {
                    opt.PreCondition(e => e.Brand != null);
                    opt.MapFrom(e => e.Brand.BrandName);
                })
                .ForMember(dest => dest.BrandLinkLogo, opt =>
                {
                    opt.PreCondition(e => e.Brand != null);
                    opt.MapFrom(e => e.Brand.ImageLink);
                })
                .ForMember(dest => dest.CarCategoryId, otp =>
                {
                    otp.PreCondition(e => e.CarCategory != null);
                    otp.MapFrom(e => e.CarCategory.Id);
                })
                .ForMember(dest => dest.CarCategory, opt =>
                {
                    opt.PreCondition(e => e.CarCategory != null);
                    opt.MapFrom(e => e.CarCategory.Category);
                });
            CreateMap<CarModelDtoForCreate, CarModel>();
            CreateMap<CarModelDtoForUpdate, CarModel>().ReverseMap();
        }
    }
}
