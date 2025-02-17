using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.User;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opts =>
                {
                    opts.PreCondition(src => src.Roles != null);
                    opts.MapFrom(src => src.Roles.FirstOrDefault()!.Name);
                })
                .ForMember(dest => dest.CitizenIdentification, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.CitizenIdentification);
                })
                .ForMember(dest => dest.Gender, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.Gender);
                })
                .ForMember(dest => dest.DateOfBirth, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.DateOfBirth);
                })
                .ForMember(dest => dest.WorkPlaceId, opt =>
                {
                    opt.PreCondition(src => src.EmployeeInfo != null);
                    opt.MapFrom(src => src.EmployeeInfo!.WorkplaceId);
                });

            CreateMap<UserForUpdateDto, User>()
                .ForAllMembers(opt =>
                {
                    opt.Condition((src, dest, srcMember) => srcMember != null);
                });

            CreateMap<UserForUpdateEmployeeDto, User>()
                .IncludeBase<UserForUpdateDto, User>()
                 .ForAllMembers(opt =>
                 {
                     opt.Condition((src, dest, srcMember) => srcMember != null);
                 }); ;
        }
    }
}
